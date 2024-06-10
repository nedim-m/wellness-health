using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using wellness.Model;
using wellness.Model.Reservation;
using wellness.Model.Treatment;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly DbWellnessContext _context;
        private readonly IMapper _mapper;
        private static ITransformer _model;
        private MLContext _mlContext;
        static object isLocked = new object();
        private static DateTime _lastTraining;
        private readonly int _daysToTrainMl;



        public RecommendationService(DbWellnessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _mlContext = new MLContext();

            if (!int.TryParse(Environment.GetEnvironmentVariable("DAYS_TO_TRAIN_ML"), out _daysToTrainMl))
            {
                throw new ArgumentException("DAYS_TO_TRAIN_ML environment variable is not a valid integer");
            }


            InitializeModel();
        }
        private void InitializeModel()
        {
          

            if (_model == null)
            {
                LoadModelFromDatabase();
                if (_model == null)
                {
                    
                    TrainAndSaveModel();
                }
            }
        }

        public void InitializeRecommendations(DateTime date)
        {
            InitializeModel();

            var mlModel = _context.MachineLearnings.OrderByDescending(m => m.TrainingTimestamp).FirstOrDefault();
            if(mlModel != null)
            {
                _lastTraining= mlModel.TrainingTimestamp;
            }

            if ((date - _lastTraining).TotalDays>=_daysToTrainMl)
            {
                TrainAndSaveModel();
            }
        }


        public List<Model.Treatment.RecommendationTreatment> GetRecommendedTreatments(int userId)
        {
           
            var userReservations = _context.Reservations
                .Where(r => r.UserId == userId)
                .Include(r => r.Treatment)
                .ToList();

         
            var userReservationTreatmentIds = userReservations.Select(ur => ur.Treatment.Id).ToList();

           
            var unratedTreatments = _context.Treatments
                .Where(t => !userReservationTreatmentIds.Contains(t.Id))
                .ToList();

            var recommendedTreatments = new List<Model.Treatment.RecommendationTreatment>();

            
            foreach (var treatment in unratedTreatments)
            {
                var mappedTreatment = _mapper.Map<Model.Treatment.Treatment>(treatment);
                mappedTreatment.TreatmentType = GetTreatmentTypeById(treatment.TreatmentTypeId);
                mappedTreatment.Category = GetCategoryById(treatment.CategoryId);

                double prediction;

                if (userReservations.Count > 0)
                {
                    
                    prediction = PredictRating(userId, treatment.Id);
                }
                else
                {
                   
                    prediction = AverageRating(treatment.Id);
                }

                if (prediction > 2.2)
                {
                    var averageRating = AverageRating(treatment.Id);
                    var treatmentToModel = _mapper.Map<Model.Treatment.Treatment>(treatment);
                    var recommendationTreatment = _mapper.Map<Model.Treatment.RecommendationTreatment>(treatmentToModel);
                    recommendationTreatment.AverageRating = averageRating;
                    recommendedTreatments.Add(recommendationTreatment);
                }
            }

            
            if (userReservations.Count <= 0)
            {
                recommendedTreatments = recommendedTreatments.OrderByDescending(t => t.AverageRating).ToList();
                recommendedTreatments = recommendedTreatments.Take(5).ToList(); 
            }

            return recommendedTreatments;
        }



        public float AverageRating(int treatmentId)
        {
            var reservationsWithRating = _context.Reservations
                .Where(x => x.TreatmentId == treatmentId && x.Status == true)
                .Where(x => _context.Ratings.Any(r => r.ReservationId == x.Id))
                .ToList();

            if (reservationsWithRating.Count == 0)
            {
                return 0.0f;
            }

            float totalRatingSum = 0;

            foreach (var reservation in reservationsWithRating)
            {
                var rating = _context.Ratings.FirstOrDefault(x => x.ReservationId == reservation.Id);

                if (rating != null)
                {
                    totalRatingSum += rating.StarRating;
                }
            }

            float averageRating = totalRatingSum / reservationsWithRating.Count;

            return averageRating;
        }

        private float PredictRating(int userId, int treatmentId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<TreatmentRating, TreatmentPrediction>(_model);
            var treatmentRating = new TreatmentRating { userId = (uint)userId, treatmentId = (uint)treatmentId };
            var prediction = predictionEngine.Predict(treatmentRating);
            return prediction.Score;
        }
        private string GetTreatmentTypeById(int treatmentTypeId)
        {

            var treatmentType = _context.TreatmentTypes.FirstOrDefault(tt => tt.Id == treatmentTypeId);
            return treatmentType?.Name ?? string.Empty;
        }

        private string GetCategoryById(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category?.Name ?? string.Empty;
        }
        private void LoadModelFromDatabase()
        {
            var mlModel =  _context.MachineLearnings.OrderByDescending(m => m.TrainingTimestamp).FirstOrDefault();
            if (mlModel != null)
            {
                using (var stream = new MemoryStream(mlModel.ModelData))
                {
                    _model = _mlContext.Model.Load(stream, out var _);
                }
            }
        }
        private void TrainAndSaveModel()
        {
            lock (isLocked)
            {
                var data = GetDataForTraining();
                _model = TrainModel(data);

                var mlModel = new MachineLearning
                {
                    ModelData = SerializeModel(_model),
                    TrainingTimestamp = DateTime.Now
                };
                _lastTraining=DateTime.Now;
                _context.MachineLearnings.Add(mlModel);
                _context.SaveChanges();
            }
        }
        private IEnumerable<TreatmentRating> GetDataForTraining()
        {
            var data = _context.Reservations
                .Where(r => r.Status == true && _context.Ratings.Any(rt => rt.ReservationId == r.Id))
                .Select(r => new TreatmentRating
                {
                    userId = (uint)r.UserId,
                    treatmentId = (uint)r.TreatmentId,
                    Label = _context.Ratings.FirstOrDefault(rt => rt.ReservationId == r.Id).StarRating
                })
                .ToList();

            return data;
        }
        private ITransformer TrainModel(IEnumerable<TreatmentRating> data)
        {
            var mlData = _mlContext.Data.LoadFromEnumerable(data);
            var dataSplit = _mlContext.Data.TrainTestSplit(mlData, testFraction: 0.2);
            var trainData = dataSplit.TrainSet;
            var testData = dataSplit.TestSet;

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = nameof(TreatmentRating.userId),
                MatrixRowIndexColumnName = nameof(TreatmentRating.treatmentId),
                LabelColumnName = nameof(TreatmentRating.Label),
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var estimator = _mlContext.Recommendation().Trainers.MatrixFactorization(options);
            var model = estimator.Fit(trainData);

            var prediction = model.Transform(testData);
            var metrics = _mlContext.Regression.Evaluate(prediction);
            Console.WriteLine($"R^2: {metrics.RSquared}");
            Console.WriteLine($"RMSE: {metrics.RootMeanSquaredError}");

            return model;
        }
        private byte[] SerializeModel(ITransformer model)
        {
            using (var stream = new MemoryStream())
            {
                _mlContext.Model.Save(model, null, stream);
                return stream.ToArray();
            }
        }

       
    }

    public class TreatmentRating
    {
        [LoadColumn(0)]
        [KeyType(count: 1000000)] 
        public uint userId;

        [LoadColumn(1)]
        [KeyType(count: 1000000)] 
        public uint treatmentId;

        [LoadColumn(2)]
        public float Label;  
    }




    public class TreatmentPrediction
    {
        public float Label;
        public float Score;
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using wellness.Model;
using wellness.Model.Reservation;
using wellness.Model.Treatment;
using wellness.Service.Database;
using wellness.Service.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wellness.Service.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly DbWellnessContext _context;
        private readonly IMapper _mapper;

        public RecommendationService(DbWellnessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            var similarTreatments = CalculateItemSimilarity(unratedTreatments, userReservations);

            var recommendedTreatments = new List<Model.Treatment.RecommendationTreatment>();

            foreach (var similarTreatment in similarTreatments)
            {
                var treatment = similarTreatment.Treatment;

               
                var averageRating = AverageRating(treatment.Id);

                var recommendationTreatment = _mapper.Map<Model.Treatment.RecommendationTreatment>(treatment);
                recommendationTreatment.AverageRating = averageRating;
               

                recommendedTreatments.Add(recommendationTreatment);
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




        private List<SimilarTreatment> CalculateItemSimilarity(List<Database.Treatment> unratedTreatments, List<Database.Reservation> userReservations)
        {
            var similarTreatments = new List<SimilarTreatment>();

            foreach (var unratedTreatment in unratedTreatments)
            {
                double similarity = CalculateCosineSimilarity(unratedTreatment, userReservations);
                var mappedTreatmen = _mapper.Map<Model.Treatment.Treatment>(unratedTreatment);
                mappedTreatmen.TreatmentType=GetTreatmentTypeById(unratedTreatment.TreatmentTypeId);
                mappedTreatmen.Category=GetCategoryById(unratedTreatment.CategoryId);
                

                similarTreatments.Add(new SimilarTreatment { Treatment = mappedTreatmen, Similarity = similarity });
            }

            return similarTreatments;
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



        private double CalculateCosineSimilarity(Database.Treatment unratedTreatment, List<Database.Reservation> userReservations)
        {
            var unratedTreatmentVector = GetTreatmentVector(unratedTreatment);

            foreach (var userReservation in userReservations)
            {
                var userTreatmentVector = GetTreatmentVector(userReservation.Treatment);

               
                double dotProduct = CalculateDotProduct(unratedTreatmentVector, userTreatmentVector);
                double magnitudeUnrated = CalculateMagnitude(unratedTreatmentVector);
                double magnitudeUser = CalculateMagnitude(userTreatmentVector);

                double cosineSimilarity = dotProduct / (magnitudeUnrated * magnitudeUser);

                
                return cosineSimilarity;
            }


            return 0.0;
        }

    
        private double CalculateDotProduct(List<double> vector1, List<double> vector2)
        {
            if (vector1.Count != vector2.Count)
                throw new ArgumentException("Vektori moraju biti iste duljine.");

            double dotProduct = 0.0;

            for (int i = 0; i < vector1.Count; i++)
            {
                dotProduct += vector1[i] * vector2[i];
            }

            return dotProduct;
        }


        private double CalculateMagnitude(List<double> vector)
        {
            double magnitude = 0.0;

            foreach (var component in vector)
            {
                magnitude += Math.Pow(component, 2);
            }

            return Math.Sqrt(magnitude);
        }


        private List<double> GetTreatmentVector(Database.Treatment treatment)
        {
           
            return new List<double>
            {
                treatment.CategoryId,
                treatment.TreatmentTypeId,
              
            };
        }
    }

  
}

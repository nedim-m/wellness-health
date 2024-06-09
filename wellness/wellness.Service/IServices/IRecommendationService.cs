using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Treatment;

namespace wellness.Service.IServices
{
    public interface IRecommendationService
    {
        List<RecommendationTreatment> GetRecommendedTreatments(int userId);
        void InitializeRecommendations();

    }
}

using DAL.Core;
using DAL.Interfaces.MachineLearning;
using DAL.Models.MachineLearning;

namespace DAL.Implementation.MachineLearning
{
    public class PredictedAgesViewership : DALObject, IPredictedAgesViewership
    {
        public PredictedAgesViewership(DatabaseContext context) : base(context)
        {
        }

        public PredictedAgeViewership Add(PredictedAgeViewership predictedAgeViewership)
        {
            PredictedAgeViewership addedPredictedGenre = _context.PredictedAgeViewerships.Add(predictedAgeViewership).Entity;
            _context.SaveChanges();
            return addedPredictedGenre;
        }

        public List<PredictedAgeViewership> GetAll()
        {
            return _context.PredictedAgeViewerships.ToList();
        }
    }
}
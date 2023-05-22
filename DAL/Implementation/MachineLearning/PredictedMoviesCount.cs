using DAL.Core;
using DAL.Interfaces.MachineLearning;
using DAL.Models;
using DAL.Models.MachineLearning;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.MachineLearning
{
    public class PredictedMoviesCount : DALObject, IPredictedMoviesCount
    {
        public PredictedMoviesCount(DatabaseContext context) : base(context)
        {
        }

        public PredictedMovieCount Add(PredictedMovieCount predictedMovieCount)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == predictedMovieCount.UserGUID);
            if (user == null)
            {
                return null;
            }

            PredictedMovieCount addedPredictedMovieCount = _context.PredictedMoviesCount.Add(predictedMovieCount).Entity;
            _context.SaveChanges();
            return addedPredictedMovieCount;
        }

        public List<PredictedMovieCount> GetAll()
        {
            return _context.PredictedMoviesCount
             .Include(p => p.User)
             .ToList();
        }

        public List<PredictedMovieCount> GetAllByDate(int year, int month)
        {
            return _context.PredictedMoviesCount
               .Include(p => p.User)
               .Where(p => p.CreatedAt.Year == year && p.CreatedAt.Millisecond == month)
               .ToList();
        }
    }
}
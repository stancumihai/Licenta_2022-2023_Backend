using DAL.Core;
using DAL.Interfaces.MachineLearning;
using DAL.Models;
using DAL.Models.MachineLearning;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.MachineLearning
{
    public class PredictedMoviesRuntime : DALObject, IPredictedMoviesRuntime
    {
        public PredictedMoviesRuntime(DatabaseContext context) : base(context)
        {
        }

        public PredictedMovieRuntime Add(PredictedMovieRuntime predictedMovieRuntime)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == predictedMovieRuntime.UserGUID);
            if (user == null)
            {
                return null;
            }

            PredictedMovieRuntime addedPredictedMovieCount = _context.PredictedMoviesRuntime.Add(predictedMovieRuntime).Entity;
            _context.SaveChanges();
            return addedPredictedMovieCount;
        }

        public List<PredictedMovieRuntime> GetAll()
        {
            return _context.PredictedMoviesRuntime
            .Include(p => p.User)
            .ToList();
        }

        public List<PredictedMovieRuntime> GetAllByDate(int year, int month)
        {
            return _context.PredictedMoviesRuntime
              .Include(p => p.User)
              .Where(p => p.CreatedAt.Year == year && p.CreatedAt.Millisecond == month)
              .ToList();
        }
    }
}
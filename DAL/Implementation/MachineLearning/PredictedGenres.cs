using DAL.Core;
using DAL.Interfaces.MachineLearning;
using DAL.Models;
using DAL.Models.MachineLearning;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.MachineLearning
{
    public class PredictedGenres : DALObject, IPredictedGenres
    {
        public PredictedGenres(DatabaseContext context) : base(context)
        {
        }

        public PredictedGenre Add(PredictedGenre predictedGenre)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == predictedGenre.UserGUID);
            if (user == null)
            {
                return null;
            }

            PredictedGenre addedPredictedGenre = _context.PredictedGenres.Add(predictedGenre).Entity;
            _context.SaveChanges();
            return addedPredictedGenre;
        }

        public List<PredictedGenre> GetAll()
        {
            return _context.PredictedGenres
                .Include(p => p.User)
                .ToList();
        }

        public List<PredictedGenre> GetAllByDate(int year, int month)
        {
            return _context.PredictedGenres
               .Include(p => p.User)
               .Where(p => p.CreatedAt.Year == year && p.CreatedAt.Millisecond == month)
               .ToList();
        }
    }
}
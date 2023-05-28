using DAL.Comparers;
using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class Recommendations : DALObject, IRecommendations
    {
        public Recommendations(DatabaseContext context) : base(context)
        {
        }

        public Recommendation Add(Recommendation recommendation)
        {
            Recommendation addedRecommendation = _context.Recommendations.Add(recommendation).Entity;
            _context.SaveChanges();
            return addedRecommendation;
        }

        public List<Recommendation> GetAll()
        {
            return _context.Recommendations
                .Include(r => r.User)
                .Include(r => r.Movie)
                .ToList();
        }

        public Recommendation Update(Recommendation newRecommendation)
        {
            Recommendation? oldRecommendation = _context.Recommendations
                .Include(r => r.User)
                .Include(r => r.Movie)
                .FirstOrDefault(r => r.RecommendationGUID == newRecommendation.RecommendationGUID);
            if (oldRecommendation == null)
            {
                return null;
            }
            UpdateFields(oldRecommendation, newRecommendation);
            _context.Recommendations.Update(oldRecommendation);
            _context.SaveChanges();
            return newRecommendation;
        }

        private static void UpdateFields(Recommendation oldRecommendation, Recommendation newRecommendation)
        {
            oldRecommendation.LikedDecisionDate = newRecommendation.LikedDecisionDate;
            oldRecommendation.IsLiked = newRecommendation.IsLiked;
            oldRecommendation.MovieGUID = newRecommendation.MovieGUID;
            oldRecommendation.UserGUID = newRecommendation.UserGUID;
            oldRecommendation.CreatedAt = newRecommendation.CreatedAt;
        }

        public Recommendation? GetByGuid(Guid guid)
        {
            return _context
                .Recommendations
                .Include(r => r.User)
                .Include(r => r.Movie)
                .FirstOrDefault(r => r.RecommendationGUID == guid);
        }

        public List<Recommendation> GetAllByUser(string userUid)
        {
            return _context
               .Recommendations
               .Where(r => r.UserGUID == userUid)
               .ToList();
        }

        public List<Recommendation> GetAllByUserYearAndMonth(string userUid, int year, int month)
        {
            List<Recommendation> recommendations = _context.Recommendations
            .Include(r => r.Movie)
            .Include(r => r.User)
            .AsEnumerable()
            .Distinct(new RecommendationComparer())
            .ToList();

            recommendations = recommendations
           .Where(r => r.UserGUID == userUid &&
                       r.CreatedAt.Month == month &&
                       r.CreatedAt.Year == year)
           .ToList();

            return recommendations;
        }

        public List<Recommendation> GetAllByYearAndMonth(int year, int month)
        {
            List<Recommendation> recommendations = _context.Recommendations
             .Include(r => r.Movie)
             .Include(r => r.User)
             .AsEnumerable()
             .Distinct(new RecommendationComparer())
             .ToList();

            recommendations = recommendations
             .Where(r => r.CreatedAt.Month == month &&
                         r.CreatedAt.Year == year)
             .ToList();

            return recommendations;
        }
    }
}
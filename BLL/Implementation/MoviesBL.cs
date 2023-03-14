using BLL.Core;
using BLL.Interfaces;
using Library.Models.Movie;

namespace BLL.Implementation
{
    public class MoviesBL : BusinessObject, IMovies
    {
        public MoviesBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public MovieCreate Add(MovieCreate movie)
        {
            _dalContext.Movies.Add(movie);
        }

        public List<MovieRead> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovieRead? GetByUid(Guid uid)
        {
            throw new NotImplementedException();
        }
    }
}
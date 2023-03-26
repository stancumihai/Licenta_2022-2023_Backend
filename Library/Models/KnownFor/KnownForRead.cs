using Library.Models.Movie;
using Library.Models.Person;

namespace Library.Models.KnownFor
{
    public class KnownForRead
    {
        public Guid Uid { get; set; }
        public MovieRead Movie { get; set; }
        public PersonRead Person { get; set; }
    }
}
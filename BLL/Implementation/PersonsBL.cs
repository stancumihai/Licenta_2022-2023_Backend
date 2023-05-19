using BLL.Converters.Person;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.Person;

namespace BLL.Implementation
{
    public class PersonsBL : BusinessObject, IPersons
    {
        public PersonsBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public PersonRead Add(PersonCreate person)
        {
            Person addedPerson = PersonCreateConverter.ToDALModel(person);
            return PersonReadConverter.ToBLLModel(_dalContext.Persons.Add(addedPerson));
        }

        public List<PersonRead> GetAll()
        {
            return _dalContext.Persons
               .GetAll()
               .Select(person => PersonReadConverter.ToBLLModel(person))
               .ToList();
        }

        public PersonRead? GetByUid(Guid uid)
        {
            return PersonReadConverter
                .ToBLLModel(_dalContext.Persons
                .GetByUid(uid)!);
        }

        public List<PersonRead> GetAllByMovieUid(Guid movieGuid)
        {
            return _dalContext.Persons
                .GetAllByMovieUid(movieGuid)
                .Select(person => PersonReadConverter.ToBLLModel(person))
                .ToList();
        }

        public List<PersonRead> GetPaginatedPersonsByProfession(string profession, int pageNumber)
        {
            return _dalContext.Persons
                .GetPaginatedPersonsByProfession(profession, pageNumber)
                .Select(person => PersonReadConverter.ToBLLModel(person))
                .ToList();
        }
        public List<PersonRead> GetAristsOfTheMonth()
        {
            List<Movie> toSearchInMovies = new(_dalContext
                                                    .LikedMovies
                                                    .GetAll()
                                                    .Select(l => l.Movie).ToList()
                                                        .Concat(_dalContext
                                                                    .SeenMovies
                                                                    .GetAll()
                                                                    .Select(s => s.Movie)
                                                                    .ToList()));
            List<Person> persons = new();
            IDictionary<Person, int> artistsDictionary = new Dictionary<Person, int>();
            foreach (Movie movie in toSearchInMovies)
            {
                persons = _dalContext.Persons.GetAllByMovieUid(movie.MovieGUID);
                foreach (Person person in persons)
                {
                    Guid personGuid = person.PersonGUID;
                    if (artistsDictionary.ContainsKey(person))
                    {
                        artistsDictionary[person]++;
                        continue;
                    }
                    artistsDictionary.Add(person, 1);
                }
            }
            IEnumerable<Person> mostappreciatedPersonsSortedDictionary = from artistDictionaryEntry in artistsDictionary
                                                                         orderby artistDictionaryEntry.Value
                                                                         descending
                                                                         select artistDictionaryEntry.Key;
            return mostappreciatedPersonsSortedDictionary.DistinctBy(d => d.Name)
                .Select(p => PersonReadConverter.ToBLLModel(p))
                .Take(10)
                .ToList();
        }
    }
}
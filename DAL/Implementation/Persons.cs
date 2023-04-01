using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class Persons : DALObject, IPersons
    {
        public Persons(DatabaseContext context) : base(context)
        {
        }

        public Person Add(Person person)
        {
            Person addedPerson = _context.Persons.Add(person).Entity;
            _context.SaveChanges();
            return addedPerson;
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person? GetByUid(Guid uid)
        {
            return _context.Persons
                .FirstOrDefault(person => person.PersonGUID == uid);
        }

        public List<Person> GetAllByMovieUid(Guid movieGuid)
        {
            return _context.KnownFor
                .Where(knownFor => knownFor.MovieGUID == movieGuid)
                .Select(kf => kf.Person)
                .ToList();
        }
    }
}
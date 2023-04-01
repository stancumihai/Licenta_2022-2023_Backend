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
    }
}
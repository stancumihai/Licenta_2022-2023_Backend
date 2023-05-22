using DAL.Models;

namespace DAL.Interfaces
{
    public interface IPersons
    {
        Person Add(Person person);
        List<Person> GetAll();
        Person? GetByUid(Guid uid);
        List<Person> GetAllByMovieUid(Guid movieGuid);
        List<Person> GetPaginatedPersonsByProfession(string profession, int pageNumber);
        List<Person> GetAllPersonsByProfession(string profession);
    }
}
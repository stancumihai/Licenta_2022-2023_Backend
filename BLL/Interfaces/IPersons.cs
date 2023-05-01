using Library.Models.Person;

namespace BLL.Interfaces
{
    public interface IPersons
    {
        PersonRead Add(PersonCreate movie);
        List<PersonRead> GetAll();
        PersonRead? GetByUid(Guid uid);
        List<PersonRead> GetAllByMovieUid(Guid movieGuid);
        List<PersonRead> GetPaginatedPersonsByProfession(string profession, int pageNumber);
        List<PersonRead> GetAristsOfTheMonth();
    }
}
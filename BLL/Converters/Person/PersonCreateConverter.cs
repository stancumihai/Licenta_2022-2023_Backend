using Library.Models.Person;

namespace BLL.Converters.Person
{
    public class PersonCreateConverter
    {
        public static PersonCreate ToBLLModel(DAL.Models.Person personDALModel)
        {
            PersonCreate personRead = new()
            {
                Name = personDALModel.Name,
                YearOfBirth = personDALModel.YearOfBirth,
                YearOfDeath = personDALModel.YearOfDeath,
                Professions = personDALModel.Professions
            };

            return personRead;
        }

        public static DAL.Models.Person ToDALModel(PersonCreate personBLLModel)
        {
            DAL.Models.Person personEntity = new()
            {
                Name = personBLLModel.Name,
                YearOfBirth = personBLLModel.YearOfBirth,
                YearOfDeath = personBLLModel.YearOfDeath,
                Professions = personBLLModel.Professions
            };

            return personEntity;
        }
    }
}
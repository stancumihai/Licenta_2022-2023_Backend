﻿using Library.Models.Person;

namespace BLL.Converters.Person
{
    public class PersonReadConverter
    {
        public static PersonRead ToBLLModel(DAL.Models.Person personDALModel)
        {
            PersonRead personRead = new()
            {
                Uid = personDALModel.PersonGUID,
                Name = personDALModel.Name,
                YearOfBirth = personDALModel.YearOfBirth,
                YearOfDeath = personDALModel.YearOfDeath,
                Profession = personDALModel.Profession
            };

            return personRead;
        }

        public static DAL.Models.Person ToDALModel(PersonRead personBLLModel)
        {
            DAL.Models.Person personEntity = new()
            {
                PersonGUID = personBLLModel.Uid,
                Name = personBLLModel.Name,
                YearOfBirth = personBLLModel.YearOfBirth,
                YearOfDeath = personBLLModel.YearOfDeath,
                Profession = personBLLModel.Profession
            };

            return personEntity;
        }
    }
}
using BLL.Converters.Movie;
using BLL.Converters.Person;
using Library.Models.KnownFor;

namespace BLL.Converters.KnownFor
{
    public class KnownForReadConverter
    {
        public static KnownForRead ToBLLModel(DAL.Models.KnownFor knownForDALModel)
        {
            KnownForRead knownForRead = new()
            {
                Uid = knownForDALModel.KnownForGUID,
                Movie = MovieReadConverter.ToBLLModel(knownForDALModel.Movie),
                Person = PersonReadConverter.ToBLLModel(knownForDALModel.Person)
            };

            return knownForRead;
        }

        public static DAL.Models.KnownFor ToDALModel(KnownForRead knownForBLLModel)
        {
            DAL.Models.KnownFor knownForEntity = new()
            {
                KnownForGUID = knownForBLLModel.Uid,
                Movie = MovieReadConverter.ToDALModel(knownForBLLModel.Movie),
                Person = PersonReadConverter.ToDALModel(knownForBLLModel.Person)
            };

            return knownForEntity;
        }
    }
}
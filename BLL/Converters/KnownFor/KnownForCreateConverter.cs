using Library.Models.KnownFor;

namespace BLL.Converters.KnownFor
{
    public class KnownForCreateConverter
    {
        public static KnownForCreate ToBLLModel(DAL.Models.KnownFor knownForDALModel)
        {
            KnownForCreate knownForRead = new()
            {
                MovieUid = knownForDALModel.MovieGUID,
                PersonUid = knownForDALModel.PersonGUID
            };

            return knownForRead;
        }

        public static DAL.Models.KnownFor ToDALModel(KnownForCreate knownForBLLModel)
        {
            DAL.Models.KnownFor knownForEntity = new()
            {
                MovieGUID = knownForBLLModel.MovieUid,
                PersonGUID = knownForBLLModel.PersonUid
            };

            return knownForEntity;
        }
    }
}
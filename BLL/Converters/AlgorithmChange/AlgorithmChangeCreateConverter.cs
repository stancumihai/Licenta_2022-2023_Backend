using Library.Models.AlgorithmChange;

namespace BLL.Converters.AlgorithmChange
{
    public class AlgorithmChangeCreateConverter
    {
        public static AlgorithmChangeCreate ToBLLModel(DAL.Models.AlgorithmChange algorithmChangeDALModel)
        {
            AlgorithmChangeCreate algorithmChangeRead = new()
            {
                AlgorithmName = algorithmChangeDALModel.AlgorithmName,
                StartDate = algorithmChangeDALModel.StartDate,
                EndDate = algorithmChangeDALModel.EndDate,
            };

            return algorithmChangeRead;
        }

        public static DAL.Models.AlgorithmChange ToDALModel(AlgorithmChangeCreate algorithmChangeBLLModel)
        {
            DAL.Models.AlgorithmChange algorithmChangeEntity = new()
            {
                AlgorithmName = algorithmChangeBLLModel.AlgorithmName,
                StartDate = algorithmChangeBLLModel.StartDate,
                EndDate = algorithmChangeBLLModel.EndDate
            };

            return algorithmChangeEntity;
        }
    }
}
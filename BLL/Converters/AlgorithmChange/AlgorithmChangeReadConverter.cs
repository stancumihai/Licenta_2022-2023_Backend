using Library.Models.AlgorithmChange;

namespace BLL.Converters.AlgorithmChange
{
    public class AlgorithmChangeReadConverter
    {
        public static AlgorithmChangeRead ToBLLModel(DAL.Models.AlgorithmChange algorithmChangeDALModel)
        {
            AlgorithmChangeRead algorithmChangeRead = new()
            {
                Uid = algorithmChangeDALModel.AlgorithmChangeGuid,
                AlgorithmName = algorithmChangeDALModel.AlgorithmName,
                StartDate = algorithmChangeDALModel.StartDate,
                EndDate = algorithmChangeDALModel.EndDate,
            };

            return algorithmChangeRead;
        }

        public static DAL.Models.AlgorithmChange ToDALModel(AlgorithmChangeRead algorithmChangeBLLModel)
        {
            DAL.Models.AlgorithmChange algorithmChangeEntity = new()
            {
                AlgorithmChangeGuid = algorithmChangeBLLModel.Uid,
                AlgorithmName = algorithmChangeBLLModel.AlgorithmName,
                StartDate = algorithmChangeBLLModel.StartDate,
                EndDate = algorithmChangeBLLModel.EndDate
            };

            return algorithmChangeEntity;
        }
    }
}
using BLL.Converters.AlgorithmChange;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.AlgorithmChange;

namespace BLL.Implementation
{
    public class AlgorithmChangesBL : BusinessObject, IAlgorithmChanges
    {
        public AlgorithmChangesBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public AlgorithmChangeCreate Add(AlgorithmChangeCreate algorithmChange)
        {

            AlgorithmChange addedAlgorithmChange = AlgorithmChangeCreateConverter.ToDALModel(algorithmChange);
            return AlgorithmChangeCreateConverter.ToBLLModel(_dalContext.AlgorithmChanges.Add(addedAlgorithmChange));
        }

        public List<AlgorithmChangeRead> GetAll()
        {
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges
                .GetAll()
                .ToList();
            algorithmChanges = (from algorithmChange in algorithmChanges
                                orderby algorithmChange.StartDate
                               ascending
                                select algorithmChange)
                         .ToList();
            return algorithmChanges
                .Select(a => AlgorithmChangeReadConverter.ToBLLModel(a))
                .ToList();
        }
    }
}
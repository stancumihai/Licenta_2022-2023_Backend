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
            return _dalContext.AlgorithmChanges
                .GetAll()
                .Select(a => AlgorithmChangeReadConverter.ToBLLModel(a))
                .ToList();
        }
    }
}
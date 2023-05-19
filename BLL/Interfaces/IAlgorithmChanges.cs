using Library.Models.AlgorithmChange;

namespace BLL.Interfaces
{
    public interface IAlgorithmChanges
    {
        AlgorithmChangeCreate Add(AlgorithmChangeCreate algorithmChange);
        List<AlgorithmChangeRead> GetAll();
    }
}
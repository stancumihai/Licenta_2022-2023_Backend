using DAL.Models;

namespace DAL.Interfaces
{
    public interface IAlgorithmChanges
    {
        AlgorithmChange Add(AlgorithmChange algorithmChange);
        List<AlgorithmChange> GetAll();
        List<AlgorithmChange> GetAllByAlgorithmName(string algorithmName);
    }
}
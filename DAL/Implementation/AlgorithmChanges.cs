using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class AlgorithmChanges : DALObject, IAlgorithmChanges
    {
        public AlgorithmChanges(DatabaseContext context) : base(context)
        {
        }

        public AlgorithmChange Add(AlgorithmChange algorithmChange)
        {
            List<AlgorithmChange> algorithmChanges = _context.AlgorithmChanges.ToList();
            if (algorithmChanges.Count != 0)
            {
                AlgorithmChange previousAlgorithmChange = algorithmChanges[algorithmChanges.Count - 1];
                previousAlgorithmChange.EndDate = algorithmChange.StartDate;
                _context.Update(previousAlgorithmChange);
            }
            AlgorithmChange addedAlgorithmChange = _context.AlgorithmChanges.Add(algorithmChange).Entity;
            _context.SaveChanges();
            return addedAlgorithmChange;
        }

        public List<AlgorithmChange> GetAll()
        {
            return _context
                .AlgorithmChanges
                .ToList();
        }

        public List<AlgorithmChange> GetAllByAlgorithmName(string algorithmName)
        {
            return _context
              .AlgorithmChanges
              .Where(a => a.AlgorithmName == algorithmName)
              .ToList();
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class AlgorithmChange
    {
        [Key]
        public Guid AlgorithmChangeGuid { get; set; }
        public string AlgorithmName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
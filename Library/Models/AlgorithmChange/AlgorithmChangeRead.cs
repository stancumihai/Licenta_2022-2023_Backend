namespace Library.Models.AlgorithmChange
{
    public class AlgorithmChangeRead
    {
        public Guid Uid { get; set; }
        public string? AlgorithmName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
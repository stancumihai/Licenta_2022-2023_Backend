namespace Library.Models.Excel
{
    public class Person
    {
        public Guid PersonGUID { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfDeath { get; set; }
        public string Professions { get; set; }
        public List<string> Movies { get; set; }
    }
}
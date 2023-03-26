namespace Library.Models.Person
{
    public class PersonRead
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfDeath { get; set; }
        public string Profession { get; set; }
    }
}
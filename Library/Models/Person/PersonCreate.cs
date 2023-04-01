namespace Library.Models.Person
{
    public class PersonCreate
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfDeath { get; set; }
        public string Professions { get; set; }
    }
}
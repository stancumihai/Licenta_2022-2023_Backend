using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Person
    {
        [Key]
        public Guid PersonGUID { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfDeath { get; set; }
        public string Profession { get; set; }
        public List<KnownFor> KnowFor { get; set; }
    }
}
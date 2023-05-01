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
        public string Professions { get; set; }
        public List<KnownFor> KnowFor { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   PersonGUID.Equals(person.PersonGUID);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PersonGUID, Name, YearOfBirth, YearOfDeath, Professions, KnowFor);
        }
    }
}
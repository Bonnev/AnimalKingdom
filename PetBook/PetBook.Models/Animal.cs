using System.Data.Entity.Spatial;

namespace PetBook.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual Breed Breed { get; set; }

        public virtual Gender Gender { get; set; }

        public DbGeography Location { get; set; }

        public double Height { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsAdopted { get; set; }
    }
}

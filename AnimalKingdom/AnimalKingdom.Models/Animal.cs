namespace AnimalKingdom.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public class Animal
    {
        public Animal()
        {
            this.Finders = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int HeightCm { get; set; }

        public virtual AnimalType Type { get; set; }

        public virtual Breed Breed { get; set; }

        [Required]
        public virtual Gender Gender { get; set; }

        [Required]
        public DbGeography Location { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsAdopted { get; set; }

        public virtual ICollection<User> Finders { get; set; }

        public virtual User Adopter { get; set; }
    }
}

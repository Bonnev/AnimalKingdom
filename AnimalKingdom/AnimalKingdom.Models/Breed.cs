namespace AnimalKingdom.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Breed
    {
        public Breed()
        {
            this.Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }

        [Required]
        public virtual AnimalType AnimalType { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}

namespace AnimalKingdom.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AnimalType
    {
        public AnimalType()
        {
            this.Breeds = new HashSet<Breed>();
        }

        public int Id { get; set; }

        [Required, MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
    }
}
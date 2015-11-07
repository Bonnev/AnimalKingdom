namespace AnimalKingdom.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Breed
    {
        public int Id { get; set; }

        [Required]
        public virtual AnimalType AnimalType { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }
    }
}

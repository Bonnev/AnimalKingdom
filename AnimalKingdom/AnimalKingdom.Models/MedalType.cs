namespace AnimalKingdom.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MedalType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
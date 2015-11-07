namespace AnimalKingdom.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Gender
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

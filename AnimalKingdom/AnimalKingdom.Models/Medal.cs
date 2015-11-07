namespace AnimalKingdom.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

namespace AnimalKingdom.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medal
    {
        public int Id { get; set; }

        [Required]
        public virtual MedalType MedalType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

namespace PetBook.Models
{
    using System.Collections.Generic;
    //using Enums;

    public class Medal
    {
        public int Id { get; set; }

        public virtual MedalType MedalType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

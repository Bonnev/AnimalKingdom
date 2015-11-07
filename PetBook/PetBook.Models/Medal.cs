namespace PetBook.Models
{
    using System.Collections.Generic;
    using Enums;

    public class Medal
    {
        private List<User> users;
        private Medals type;

        public Medal(Medals type)
        {
            this.Users = new List<User>();
            this.Type = type;
        }

        public List<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public Medals Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}

namespace PetBook.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public User()
        {
            this.FoundAnimals = new HashSet<Animal>();
            this.AdoptedAnimals = new HashSet<Animal>();
            this.Donations = new HashSet<Donation>();
            this.Medals = new HashSet<Medal>();
        }

        public DbGeography Location { get; set; }

        public virtual ICollection<Animal> FoundAnimals { get; set; }

        public virtual ICollection<Animal> AdoptedAnimals { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }

        public virtual ICollection<Medal> Medals { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}

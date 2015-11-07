namespace PetBook.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class PetBookDbContext : IdentityDbContext<User>
    {
        public PetBookDbContext()
            : base("PetBookConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Medal> Medals { get; set; }

        public DbSet<MedalType> MedalTypes { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public static PetBookDbContext Create()
        {
            return new PetBookDbContext();
        }
    }
}

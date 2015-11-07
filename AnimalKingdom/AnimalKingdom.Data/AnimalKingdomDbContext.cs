namespace AnimalKingdom.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class AnimalKingdomDbContext : IdentityDbContext<User>
    {
        public AnimalKingdomDbContext()
            : base("AnimalKingdomConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Medal> Medals { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public static AnimalKingdomDbContext Create()
        {
            return new AnimalKingdomDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOptional(a => a.Adopter)
                .WithMany(u => u.AdoptedAnimals);
            modelBuilder.Entity<Animal>()
                .HasMany(a => a.Finders)
                .WithMany(u => u.FoundAnimals)
                .Map(m => m.MapLeftKey("AnimalId").MapRightKey("FinderId"));
            base.OnModelCreating(modelBuilder);
        }
    }
}

namespace AnimalKingdom.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common;

    public sealed class Configuration : DbMigrationsConfiguration<AnimalKingdomDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AnimalKingdomDbContext context)
        {
            SeedAdminRoleAndAddAdmin(context);
            SeedAnimalTypes(context);
            SeedBreeds(context);
            SeedGenders(context);
            SeedMedals(context);
        }

        private static void SeedAdminRoleAndAddAdmin(AnimalKingdomDbContext context)
        {
            const string AdminRoleName = "Administrator";
            if (!context.Roles.Any(r => r.Name == AdminRoleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole(AdminRoleName);

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var admin = new User() { UserName = "admin", Email = "admin@animalkingdom.app" };

                manager.Create(admin, AppKeys.DefaultAdminPassword);
                manager.AddToRole(admin.Id, AdminRoleName);
            }
        }

        private static void SeedAnimalTypes(AnimalKingdomDbContext context)
        {
            context.AnimalTypes.AddOrUpdate(type => type.Id,
                new AnimalType() { Id = 1, Name = "Куче" },
                new AnimalType() { Id = 2, Name = "Котка" },
                new AnimalType() { Id = 3, Name = "Заек" },
                new AnimalType() { Id = 4, Name = "Хамстер" },
                new AnimalType() { Id = 5, Name = "Птица" },
                new AnimalType() { Id = 6, Name = "Неизвестен" });
            context.SaveChanges();
        }

        private static void SeedBreeds(AnimalKingdomDbContext context)
        {
            context.Breeds.AddOrUpdate(breed => breed.Id,
                new Breed() { Id = 1, Name = "Хъски", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Куче") },
                new Breed() { Id = 2, Name = "Лабрадор", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Куче") },
                new Breed() { Id = 3, Name = "Самоед", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Куче") },
                new Breed() { Id = 4, Name = "Доберман", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Куче") },
                new Breed() { Id = 5, Name = "Немска овчарка", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Куче") },
                new Breed() { Id = 6, Name = "Британска късокосместа", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Котка") },
                new Breed() { Id = 7, Name = "Синя руска", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Котка") },
                new Breed() { Id = 8, Name = "Сиамска котка", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Котка") },
                new Breed() { Id = 9, Name = "Персийска котка", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Котка") },
                new Breed() { Id = 10, Name = "Европейска котка", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "Котка") });
            context.SaveChanges();
        }

        private static void SeedGenders(AnimalKingdomDbContext context)
        {
            context.Genders.AddOrUpdate(gender => gender.Id,
               new Gender() { Id = 1, Name = "Мъжки" },
               new Gender() { Id = 2, Name = "Женски" },
               new Gender() { Id = 3, Name = "Неизвестен" });
            context.SaveChanges();
        }

        private static void SeedMedals(AnimalKingdomDbContext context)
        {
            context.Medals.AddOrUpdate(medal => medal.Id,
               new Medal() { Id = 1, Name = "5 дарения", Description = "Притежателят на този медал е направил 5 дарения за животни в нужда", PictureUrl = "five-donations.png" },
               new Medal() { Id = 1, Name = "3 осиновени животни", Description = "Притежателят на този медал има златно сърце и е осиновил 3 животни чрез системата", PictureUrl = "three-adopted-animals.png" });
            context.SaveChanges();
        }
    }
}

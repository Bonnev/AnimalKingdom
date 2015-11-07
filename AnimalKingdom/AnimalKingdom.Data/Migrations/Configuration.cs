namespace AnimalKingdom.Data.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
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
            var newtype = new AnimalType() { Id = 1, Name = "����" };
            string str = "��������";
            string str2 = System.IO.File.ReadAllText(@"D:\AnimalKingdom\AnimalKingdom\AnimalKingdom.Data\Migrations\TextFile1.txt");
            context.AnimalTypes.AddOrUpdate(type => type.Id,
                new AnimalType() { Id = 1, Name = "����" },
                new AnimalType() { Id = 2, Name = "�����" },
                new AnimalType() { Id = 3, Name = "����" },
                new AnimalType() { Id = 4, Name = "�������" },
                new AnimalType() { Id = 5, Name = "�����" },
                new AnimalType() { Id = 6, Name = "����������" });
            context.SaveChanges();
        }

        private static void SeedBreeds(AnimalKingdomDbContext context)
        {
            context.Breeds.AddOrUpdate(breed => breed.Id,
                new Breed() { Name = "�����", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "����") },
                new Breed() { Name = "��������", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "����") },
                new Breed() { Name = "������", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "����") },
                new Breed() { Name = "��������", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "����") },
                new Breed() { Name = "������ �������", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "����") },
                new Breed() { Name = "��������� ������������", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "�����") },
                new Breed() { Name = "���� �����", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "�����") },
                new Breed() { Name = "������� �����", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "�����") },
                new Breed() { Name = "��������� �����", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "�����") },
                new Breed() { Name = "���������� �����", AnimalType = context.AnimalTypes.FirstOrDefault(type => type.Name == "�����") });
            context.SaveChanges();
        }

        private static void SeedGenders(AnimalKingdomDbContext context)
        {
            context.Genders.AddOrUpdate(gender => gender.Id,
               new Gender() { Id = 1, Name = "�����" },
               new Gender() { Id = 2, Name = "������" },
               new Gender() { Id = 3, Name = "����������" });
            context.SaveChanges();
        }

        private static void SeedMedals(AnimalKingdomDbContext context)
        {
            context.Medals.AddOrUpdate(medal => medal.Id,
               new Medal() { Id = 1, Name = "5 �������", Description = "������������ �� ���� ����� � �������� 5 ������� �� ������� � �����", PictureUrl = "five-donations.png" },
               new Medal() { Id = 1, Name = "3 ��������� �������", Description = "������������ �� ���� ����� ��� ������ ����� � � �������� 3 ������� ���� ���������", PictureUrl = "three-adopted-animals.png" });
            context.SaveChanges();
        }
    }
}

namespace PetBook.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface IPetBookData
    {
        IRepository<User> Users { get; }

        IRepository<Animal> Animals { get; }

        IRepository<AnimalType> AnimalTypes { get; }

        IRepository<Breed> Breeds { get; }

        IRepository<Gender> Genders { get; }

        IRepository<Medal> Medals { get; }

        IRepository<MedalType> MedalTypes { get; }

        IRepository<Donation> Donations { get; }

        IRepository<Event> Events { get; }

        IRepository<EventType> EventTypes { get; }

        void SaveChanges();
    }
}

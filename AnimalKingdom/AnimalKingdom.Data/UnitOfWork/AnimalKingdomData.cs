namespace AnimalKingdom.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;
    using Repositories;

    public class AnimalKingdomData : IAnimalKingdomData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public AnimalKingdomData()
            : this(new AnimalKingdomDbContext())
        {
        }

        public AnimalKingdomData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Animal> Animals
        {
            get { return this.GetRepository<Animal>(); }
        }

        public IRepository<AnimalType> AnimalTypes
        {
            get { return this.GetRepository<AnimalType>(); }
        }

        public IRepository<Breed> Breeds
        {
            get { return this.GetRepository<Breed>(); }
        }

        public IRepository<Gender> Genders
        {
            get { return this.GetRepository<Gender>(); }
        }

        public IRepository<Medal> Medals
        {
            get { return this.GetRepository<Medal>(); }
        }

        public IRepository<Donation> Donations
        {
            get { return this.GetRepository<Donation>(); }
        }

        public IRepository<Event> Events
        {
            get { return this.GetRepository<Event>(); }
        }

        public IRepository<EventType> EventTypes
        {
            get { return this.GetRepository<EventType>(); }
        }

        public IRepository<FacebookPage> FacebookPages
        {
            get { return this.GetRepository<FacebookPage>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}

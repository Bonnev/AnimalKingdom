namespace PetBook.Models
{
    using System.Collections.Generic;

    public class AnimalType
    {
        public AnimalType()
        {
            this.Breeds = new HashSet<Breed>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
    }
}
namespace PetBook.Models
{
    public class Breed
    {
        public int Id { get; set; }

        public virtual PetType PetType { get; set; }

        public string Name { get; set; }
    }
}

namespace PetBook.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public decimal Amount { get; set; }
    }
}

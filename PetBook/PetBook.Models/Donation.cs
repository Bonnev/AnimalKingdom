namespace PetBook.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public DonationType Type { get; set; }

        public decimal? Amount { get; set; }

        public double? WeightKg { get; set; }

        public string Description { get; set; }
    }
}

namespace PetBook.Models
{
    public class Donation
    {
        private User user;
        private decimal amount;

        public Donation(User user, decimal amount)
        {
            this.user = user;
            this.amount = amount;
        }

        public User User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
    }
}

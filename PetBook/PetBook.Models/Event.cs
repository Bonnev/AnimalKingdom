namespace PetBook.Models
{
    using System;

    public class Event
    {
        private DateTime startDate;
        private DateTime endDate;
        private string place;
        private string type;

        public Event(DateTime startDate, DateTime endDate, string place, string type)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Place = place;
            this.Type = type;
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}

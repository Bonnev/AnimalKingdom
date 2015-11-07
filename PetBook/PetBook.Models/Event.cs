namespace PetBook.Models
{
    using System;
    using System.Data.Entity.Spatial;

    public class Event
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DbGeography Location { get; set; }

        public virtual EventType Type { get; set; }
    }
}

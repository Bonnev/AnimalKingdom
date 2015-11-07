namespace AnimalKingdom.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public class Event
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public DbGeography Location { get; set; }

        public virtual EventType Type { get; set; }
    }
}

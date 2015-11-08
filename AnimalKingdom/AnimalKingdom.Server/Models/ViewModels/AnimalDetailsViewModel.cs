using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace AnimalKingdom.Server.Models.ViewModels
{
    public class AnimalDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Години")]
        public int Age { get; set; }

        [Display(Name = "Височина (cm)")]
        public int HeightCm { get; set; }

        [Display(Name = "Тип")]
        public string Type { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Display(Name = "Местоположение")]
        public DbGeography Location { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Открито от")]
        public IEnumerable<string> FinderNames { get; set; }

        [Display(Name = "Осиновено")]
        public bool IsAdopted { get; set; }

        [Display(Name = "Осиновител")]
        public string AdopterName { get; set; }
    }
}
namespace AnimalKingdom.Server.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public class AnimalBindingModel
    {

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Години")]
        [Range(0, 20, ErrorMessage = "{0}те трябва да бъде между {1} и {2}")]
        public int Age { get; set; }

        [Display(Name = "Височина (cm)")]
        [Range(0, 400, ErrorMessage = "{0}та трябва да бъде между {1} и {2} cm")]
        public int Height { get; set; }

        [Display(Name = "Тип")]
        public int TypeId { get; set; }

        [Display(Name = "Порода")]
        public int? BreedId { get; set; }

        [Display(Name = "Пол")]
        public int GenderId { get; set; }

        [Display(Name = "Местоположение")]
        public DbGeography Location { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Открихме животното с")]
        public string[] OtherFinderIds { get; set; }
    }
}
namespace AnimalKingdom.Server.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AnimalBindingModel
    {

        [Display(Name = "Име")]
        [Required(ErrorMessage = "{0}то е задължително")]
        public string Name { get; set; }

        [Display(Name = "Години")]
        [Required(ErrorMessage = "{0}тe са задължителни")]
        [Range(0, 20, ErrorMessage = "{0}те трябва да бъдат между {1} и {2}")]
        public int Age { get; set; }

        [Display(Name = "Височина (cm)")]
        [Required(ErrorMessage = "Височината е задължителна")]
        [Range(0, 400, ErrorMessage = "Височината трябва да бъде между {1} и {2} cm")]
        public int HeightCm { get; set; }

        [Display(Name = "Тип")]
        public int TypeId { get; set; }

        [Display(Name = "Порода")]
        public int? BreedId { get; set; }

        [Display(Name = "Пол")]
        public int GenderId { get; set; }

        [Display(Name = "Местоположение")]
        public string Location { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Открито с")]
        public string OtherFinderNames { get; set; }
    }
}
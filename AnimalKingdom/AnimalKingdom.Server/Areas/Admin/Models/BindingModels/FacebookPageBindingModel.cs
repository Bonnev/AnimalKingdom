using System.ComponentModel.DataAnnotations;

namespace AnimalKingdom.Server.Areas.Admin.Models.BindingModels
{
    public class FacebookPageBindingModel
    {
        [Display(Name = "Линк")]
        [Url(ErrorMessage = "Линкът не е валиден")]
        public string Link { get; set; }

        [Display(Name = "Заглавие")]
        [MinLength(3, ErrorMessage = "Заглавието трябва да е с дължина поне 3 символа")]
        public string Title { get; set; }
    }
}
namespace AnimalKingdom.Server.Models.ViewModels
{
    public class FilterDescriptionViewModel
    {
        public string Value { get; set; }

        public string Operator { get; set; }

        public string Field { get; set; }

        public string IgnoreCase { get; set; }
    }
}
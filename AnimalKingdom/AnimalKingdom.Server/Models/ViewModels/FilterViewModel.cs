namespace AnimalKingdom.Server.Models.ViewModels
{
    using System.Collections.Generic;

    public class FilterViewModel
    {
        public string Logic { get; set; }

        public IEnumerable<FilterDescriptionViewModel> Filters { get; set; }
    }
}
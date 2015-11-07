namespace AnimalKingdom.Server.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.BindingModels;
    using System.Linq;

    public class AnimalsController : BaseController
    {
        public AnimalsController(IAnimalKingdomData data)
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            ViewBag.Genders = this.Data.Genders.All()
                .Select(g => new SelectListItem() { Text = g.Name, Value = g.Id.ToString() });
            ViewBag.Types = this.Data.AnimalTypes.All()
                .Select(t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString() });
            // TODO: Connect to 1st select list
            ViewBag.Breeds = this.Data.Breeds.All()
                .Select(b => new SelectListItem() { Text = b.Name, Value = b.Id.ToString() });
            return this.View();
        }

        [HttpPost]
        [Authorize, ValidateAntiForgeryToken]
        public ActionResult Add(AnimalBindingModel model)
        {
            return this.View();
        }
    }
}
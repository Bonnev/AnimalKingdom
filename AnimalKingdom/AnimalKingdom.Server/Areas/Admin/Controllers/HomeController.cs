namespace AnimalKingdom.Server.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class HomeController : BaseAdminController
    {
        public HomeController(IAnimalKingdomData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
namespace AnimalKingdom.Server.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(IAnimalKingdomData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}
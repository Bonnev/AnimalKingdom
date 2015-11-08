namespace AnimalKingdom.Server.Areas.Admin.Controllers
{
    using Data.UnitOfWork;
    using Server.Controllers;
    using System.Web.Mvc;

    [Authorize(Roles = "Administrator")]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(IAnimalKingdomData data)
            : base(data)
        {
        }
    }
}
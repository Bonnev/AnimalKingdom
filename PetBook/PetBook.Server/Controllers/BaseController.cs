namespace PetBook.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.UnitOfWork;
    using PetBook.Models;

    public class BaseController : Controller
    {
        private IPetBookData data;
        private User userProfile;

        protected BaseController(IPetBookData data)
        {
            this.Data = data;
        }

        protected BaseController(IPetBookData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IPetBookData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
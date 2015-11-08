namespace AnimalKingdom.Server.Controllers
{
    using AnimalKingdom.Data.UnitOfWork;
    using AnimalKingdom.Server.Models.ViewModels;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class UsersController : BaseController
    {
        public UsersController(IAnimalKingdomData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult All(FilterViewModel filter)
        {
            string currentUserId = User.Identity.GetUserId();
            var users = this.Data.Users.All();
            foreach (var filterModel in filter.Filters)
            {
                if (filterModel.Operator == "contains")
                {
                    users = users.Where(u => u.UserName.ToLower().Contains(filterModel.Value.ToLower()));
                }
                else if (filterModel.Operator == "neq")
                {
                    users = users.Where(u => u.UserName != filterModel.Value);
                }
            }

            // Remove the current user as s/he is already in the finders list,
            // and take no more than 3 records (to avoid server overload)
            users = users
                .Where(u => u.Id != currentUserId)
                .OrderBy(u => u.Id)
                .Take(3);
            var model = Mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            return this.Json(model);
        }
    }
}
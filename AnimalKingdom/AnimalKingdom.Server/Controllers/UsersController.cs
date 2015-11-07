using AnimalKingdom.Data.UnitOfWork;
using AnimalKingdom.Server.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalKingdom.Server.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IAnimalKingdomData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult All(FilterViewModel filter)
        {
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

            var model = Mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            return this.Json(model);
        }
    }
}
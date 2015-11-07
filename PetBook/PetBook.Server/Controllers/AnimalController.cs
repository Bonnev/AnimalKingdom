using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetBook.Server.Controllers
{
    using PetBook.Data;

    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult AddAnimal()
        {
            return View();
        }

        public ActionResult ViewAnimals()
        {
            var context = new PetBookDbContext();
            var items = context.AnimalTypes.Select(item => item.Name);
            return View();
        }
    }
}
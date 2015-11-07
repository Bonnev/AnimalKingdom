using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalKingdom.Server.Controllers
{
    using AnimalKingdom.Data;

    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult AddAnimal()
        {
            return View();
        }

        public ActionResult ViewAnimals()
        {
            return View();
        }
    }
}
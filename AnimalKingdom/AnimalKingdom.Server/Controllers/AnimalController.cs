using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalKingdom.Server.Controllers
{
    using System.Data.Entity.Spatial;

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

        
        public string Evaluate(string coordinates)
        {
            //string id, string dataToEvaluate)
            //'idHideen', dataToEvaluate: event.latLng
            string latitude = coordinates.Substring(1, coordinates.IndexOf(' ') - 2);
            string longitude = coordinates.Substring(coordinates.IndexOf(' ') + 1, coordinates.Length - coordinates.IndexOf(' ') - 2);
            string pointString = string.Format("POINT({0} {1})", longitude, latitude);
            var geo = DbGeography.FromText(pointString);
            return pointString;
        }
    }
}
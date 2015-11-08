namespace AnimalKingdom.Server.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;
    using AnimalKingdom.Models;
    using Data.UnitOfWork;
    using Models.BindingModels;
    using AutoMapper;
    using Models.ViewModels;

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
                .Select(t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString(), Selected = t.Name == "Неизвестен" });
            ViewBag.Breeds = new List<SelectListItem>() { new SelectListItem() { Text = "Изберете тип", Value = "0" } };
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AnimalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Add");
            }

            var animal = new Animal();
            animal.Name = model.Name;
            animal.Age = model.Age;
            animal.HeightCm = model.HeightCm;
            animal.AdditionalInformation = model.AdditionalInformation;

            var gender = this.Data.Genders.All().FirstOrDefault(g => g.Id == model.GenderId);
            var type = this.Data.AnimalTypes.All().FirstOrDefault(t => t.Id == model.TypeId);
            var breed = this.Data.Breeds.All().FirstOrDefault(b => b.Id == model.BreedId);
            animal.Finders = new List<User>() { this.UserProfile };
            var otherFinderNames = model.OtherFinderNames == null ? null : model.OtherFinderNames.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            if (otherFinderNames != null)
            {
                var otherFinders = this.Data.Users.All().Where(u => otherFinderNames.Contains(u.UserName)).ToList();
                foreach (var otherFinder in otherFinders)
                {
                    animal.Finders.Add(otherFinder);
                }
            }

            animal.Gender = gender;
            animal.Type = type;
            animal.Breed = breed;
            string[] locationParts = model.Location.Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            animal.Location = DbGeography.FromText(string.Format("POINT ({0} {1})", locationParts[1], locationParts[0]));
            this.Data.Animals.Add(animal);
            this.Data.SaveChanges();
            return this.RedirectToAction("Details", routeValues: new { id = animal.Id });
        }

        public ActionResult Details(int id)
        {
            var animal = this.Data.Animals.Find(id);
            if (animal == null)
            {
                return this.HttpNotFound();
            }

            var model = Mapper.Map<AnimalDetailsViewModel>(animal);
            return this.View(model);
        }

        public ActionResult Locations()
        {
            var locations = this.Data.Animals.All();
            var model = Mapper.Map<IEnumerable<AnimalLocationViewModel>>(locations);
            return this.Json(model);
        }

        public ActionResult Adopt(int id)
        {
            ViewBag.AnimalName = this.Data.Animals.Find(id).Name;
            return this.View();
        }
    }
}
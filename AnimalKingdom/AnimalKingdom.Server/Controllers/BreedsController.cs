namespace AnimalKingdom.Server.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using AutoMapper;
    using Models.ViewModels;
    using System.Collections.Generic;

    public class BreedsController : BaseController
    {
        public BreedsController(IAnimalKingdomData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult All(int id)
        {
            var breeds = this.Data.Breeds.All()
                .Where(b => b.AnimalType.Id == id)
                .OrderBy(b=>b.Name);
            var model = Mapper.Map<IEnumerable<BreedConciseViewModel>>(breeds);
            return this.Json(model);
        }
    }
}
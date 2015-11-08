namespace AnimalKingdom.Server.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using Models.BindingModels;
    using System.Text.RegularExpressions;
    using AnimalKingdom.Models;
    using AutoMapper;
    using Models;
    using Models.ViewModels;

    public class FacebookPagesController : BaseAdminController
    {
        public FacebookPagesController(IAnimalKingdomData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            var pages = this.Data.FacebookPages.All()
                .Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() });
            return this.PartialView("_All", pages);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(FacebookPageBindingModel model)
        {
            var match = Regex.Match(model.Link, @"/(?:https?:\/\/)?(?:www\.)?facebook\.com\/(?:(?:\w)*#!\/)?(?:pages\/)?(?:[\w\-]*\/)*([\w\-\.]*)/");
            if (match.Groups.Count >= 2)
            {
                var pageId = match.Groups[1].Value;
                if (Regex.IsMatch(pageId, @"\-(\d+)"))
                {
                    pageId = Regex.Match(pageId, @"\-(\d+)").Groups[1].Value;
                }

                var fbPage = new FacebookPage() { FacebookId = pageId, Name = model.Title };
                this.Data.FacebookPages.Add(fbPage);
                this.Data.SaveChanges();
            }
            else
            {
                ViewBag.Message = "Страницата не може да бъде добавена";
                this.RedirectToAction("Add");
            }

            return this.RedirectToAction("Index", new { controller = "Home", area = "Admin" });
        }

        public ActionResult Details(int id)
        {
            var page = this.Data.FacebookPages.Find(id);
            var model = Mapper.Map<FacebookPageViewModel>(page);
            ViewBag.CurrentPageId = page.Id;
            return this.View(model);
        }
    }
}

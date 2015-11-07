namespace PetBook.Server
{
    using PetBook.Data;
    using PetBook.Data.Migrations;
    using PetBook.Server.App_Start;
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetBookDbContext, Configuration>());

            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);
        }
    }
}

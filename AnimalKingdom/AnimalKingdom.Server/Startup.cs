using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalKingdom.Server.Startup))]
namespace AnimalKingdom.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

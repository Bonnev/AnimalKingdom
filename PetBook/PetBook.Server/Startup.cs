using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetBook.Server.Startup))]
namespace PetBook.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

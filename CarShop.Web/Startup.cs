using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarShop.Web.Startup))]
namespace CarShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

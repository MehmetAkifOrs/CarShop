using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarShop.Admin.Startup))]
namespace CarShop.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

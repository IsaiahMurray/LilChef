using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LilChef.MVC.Startup))]
namespace LilChef.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

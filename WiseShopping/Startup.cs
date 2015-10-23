using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheBesShopping.Startup))]
namespace TheBesShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

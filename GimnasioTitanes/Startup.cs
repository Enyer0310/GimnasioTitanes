using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GimnasioTitanes.Startup))]
namespace GimnasioTitanes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

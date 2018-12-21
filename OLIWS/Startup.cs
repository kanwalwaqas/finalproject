using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OLIWS.Startup))]
namespace OLIWS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

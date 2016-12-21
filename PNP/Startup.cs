using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PNP.Startup))]
namespace PNP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

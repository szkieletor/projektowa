using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Urlopy.Startup))]
namespace Urlopy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

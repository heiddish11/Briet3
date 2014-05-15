using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Briet3.Startup))]
namespace Briet3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

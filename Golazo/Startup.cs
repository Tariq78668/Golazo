using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Golazo.Startup))]
namespace Golazo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

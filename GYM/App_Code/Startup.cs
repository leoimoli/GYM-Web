using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GYM.Startup))]
namespace GYM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

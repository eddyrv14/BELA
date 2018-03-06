using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bela.UI.Startup))]
namespace Bela.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

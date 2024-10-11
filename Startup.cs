using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppMusicCatalog.Startup))]
namespace WebAppMusicCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

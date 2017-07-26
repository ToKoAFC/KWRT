using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KWRT.Web.Startup))]
namespace KWRT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

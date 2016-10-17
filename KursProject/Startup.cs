using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KursProject.Startup))]
namespace KursProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

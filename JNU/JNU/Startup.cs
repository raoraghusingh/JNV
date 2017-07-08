using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JNU.Startup))]
namespace JNU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

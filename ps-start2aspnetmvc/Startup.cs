using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ps_start2aspnetmvc.Startup))]
namespace ps_start2aspnetmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

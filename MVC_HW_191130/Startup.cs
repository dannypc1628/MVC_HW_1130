using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_HW_191130.Startup))]
namespace MVC_HW_191130
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

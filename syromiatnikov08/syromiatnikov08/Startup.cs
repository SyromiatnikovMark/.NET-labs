using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(syromiatnikov08.Startup))]
namespace syromiatnikov08
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

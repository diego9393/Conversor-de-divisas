using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyecto_final.Startup))]
namespace proyecto_final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

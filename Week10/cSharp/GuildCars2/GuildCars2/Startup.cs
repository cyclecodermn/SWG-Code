using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildCars2.Startup))]
namespace GuildCars2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

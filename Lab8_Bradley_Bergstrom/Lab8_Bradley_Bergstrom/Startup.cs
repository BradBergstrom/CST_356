using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab8_Bradley_Bergstrom.Startup))]
namespace Lab8_Bradley_Bergstrom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

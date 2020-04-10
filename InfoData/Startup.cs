using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfoData.Startup))]
namespace InfoData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

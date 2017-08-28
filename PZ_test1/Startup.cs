using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PZ_test1.Startup))]
namespace PZ_test1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

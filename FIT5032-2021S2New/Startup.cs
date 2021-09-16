using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032_2021S2New.Startup))]
namespace FIT5032_2021S2New
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

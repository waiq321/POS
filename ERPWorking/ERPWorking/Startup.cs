using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERPWorking.Startup))]
namespace ERPWorking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

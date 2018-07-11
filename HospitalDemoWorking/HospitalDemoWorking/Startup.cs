using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalDemoWorking.Startup))]
namespace HospitalDemoWorking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dinesty.Startup))]
namespace Dinesty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

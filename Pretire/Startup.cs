using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pretire.Startup))]
namespace Pretire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

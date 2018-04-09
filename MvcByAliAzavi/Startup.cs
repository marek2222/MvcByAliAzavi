using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcByAliAzavi.Startup))]
namespace MvcByAliAzavi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

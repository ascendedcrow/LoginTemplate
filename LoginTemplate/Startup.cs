using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginTemplate.Startup))]
namespace LoginTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

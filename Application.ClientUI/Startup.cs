using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Application.ClientUI.Startup))]
namespace Application.ClientUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

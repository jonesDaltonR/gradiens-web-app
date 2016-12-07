using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gradiens.Startup))]
namespace Gradiens
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

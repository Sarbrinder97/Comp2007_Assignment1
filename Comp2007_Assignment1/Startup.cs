using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comp2007_Assignment1.Startup))]
namespace Comp2007_Assignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

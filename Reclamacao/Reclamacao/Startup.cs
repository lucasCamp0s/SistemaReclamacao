using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reclamacao.Startup))]
namespace Reclamacao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

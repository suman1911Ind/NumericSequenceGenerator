using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Calculator.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocConfig.Configure();
        }
    }
}

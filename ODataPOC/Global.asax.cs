using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ODataPOC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        
        
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            string authHeader = HttpContext.Current.Request.Headers["Authorization"];
            HttpApplication application = (HttpApplication)sender;
            if (authHeader == "Bearer")
            {
                application.Context.Response.AddHeader("WWW-Authenticate", "authorization_uri=https://localhost.fiddler:44302/adfs/oauth2/authorize");
                //application.Context.Response.AddHeader("WWW-Authenticate", "authorization_uri=https://login.windows.net");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAppMusicCatalog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_BeginRequest()
        //{
        //    //if(HttpContext.Current.Session!=null)
        //    //    if (HttpContext.Current.Session["Usuario"] == null && !HttpContext.Current.Request.Url.AbsolutePath.Contains("Account"))
            
        //        //if (!HttpContext.Current.Request.Url.AbsolutePath.Contains("Account"))
        //        //{
        //            HttpContext.Current.Response.Redirect("~/Account/Login2");
        //        //}
        //}

    }
}

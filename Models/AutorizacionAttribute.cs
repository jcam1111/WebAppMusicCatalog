using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMusicCatalog.Models
{
    public class AutorizacionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionUsuario = filterContext.HttpContext.Session["Usuario"];
            if (sessionUsuario == null)
            {
                //filterContext.Result = new RedirectResult("~/Login/Index");
                HttpContext.Current.Response.Redirect("~/Account/Login2");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}





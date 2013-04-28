using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CJCProjectEstimatorMVC
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
                //return false;
            HttpContextWrapper context = new HttpContextWrapper(System.Web.HttpContext.Current);

            if (context.Session != null)
            {
                Int32? userId = (Int32?)context.Session["UserId"];
                if (userId != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
            
        }
    }
}
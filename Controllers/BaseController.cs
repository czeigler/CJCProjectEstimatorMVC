using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJCProjectEstimatorMVC.Controllers
{
    public class BaseController : Controller
    {

        protected Int32 getCurrentUserId()
        {
            return (Int32) Session["UserId"];
        }

        protected Boolean isLoggedIn()
        {
            return getCurrentUserId() != null;
        }

        protected void setLoggedIn(Int32 rhs)
        {
            Session["UserId"] = rhs;
        }

        protected void setLoggedOut()
        {
            Session["UserId"] = null;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJCProjectEstimatorMVC.Controllers
{
    abstract public class BaseController : Controller
    {

        protected Int32? getCurrentUserId()
        {
            if (Session != null && Session["UserId"] != null)
            {
                return (Int32?)Session["UserId"];
            }
            else
            {
                return null;
            }
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

        //protected abstract bool getRequiresLogin();

    }
}

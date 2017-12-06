using GroceryMart.WebApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMart.WebApp.Areas.User.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter(Roles = "User")]
    public class BaseController : Controller
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}
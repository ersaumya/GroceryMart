using GroceryMart.BAL;
using GroceryMart.WebApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMart.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}
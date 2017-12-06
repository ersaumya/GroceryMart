using GroceryMart.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMart.WebApp.Areas.Admin.Controllers
{


    // GET: Admin/Home
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow) : base(uow)
        {
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            string name = CurrentUser.Name;
            return View();
        }
    }

}
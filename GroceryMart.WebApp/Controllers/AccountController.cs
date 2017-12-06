using GroceryMart.BAL;
using GroceryMart.DomainModels.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GroceryMart.WebApp.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork uow) : base(uow)
        {

        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        // GET: Account
        public ActionResult Login()
        {
            try
            {
                int a = 2, b = 0;
                int c = a / b;
            }
            catch (Exception ex)
            {

                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserViewModel user = _uow.AuthenticateRepo.ValidateUser(model.Username, model.Password);
            if (user != null)
            {
                string data = JsonConvert.SerializeObject(user);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, data);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(cookie);
                if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
            }
            return View();
        }
        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}
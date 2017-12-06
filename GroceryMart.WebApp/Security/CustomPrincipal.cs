using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace GroceryMart.WebApp.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }
        //authentication
        public IIdentity Identity { get; private set; }

        //authorization
        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Token {
            get
            {
                string authHeader = Username + ":" + Password;
                authHeader = Convert.ToBase64String(Encoding.Default.GetBytes(authHeader));
                return authHeader;
            }
        }

        public string Password { get; set; }

        public string ContactNo { get; set; }
        public string[] Roles { get; set; }
    }
}
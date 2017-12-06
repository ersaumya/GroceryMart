using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMart.WebApp.Security
{
    public abstract class CustomBasePage : WebViewPage
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }
    public abstract class CustomeBasePage<TModel> : WebViewPage<TModel>
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }
}
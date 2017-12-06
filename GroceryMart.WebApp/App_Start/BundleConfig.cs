using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
namespace GroceryMart.WebApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css").Include("~/Content/Site.css", "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/js").Include("~/Scripts/jquery-1.10.2.js","~/Scripts/bootstrap.js", "~/Scripts/jquery.validate.js", "~/Scripts/jquery.validate.unobtrusive.js"));
        }
    }
}
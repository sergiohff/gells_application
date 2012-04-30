using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //BundleTable.Bundles.Add(EnableJSBootstrap());
            //BundleTable.Bundles.Add(EnableCSSBootstrap());
            //BundleTable.Bundles.RegisterTemplateBundles();
        }

        //public Bundle EnableCSSBootstrap()
        //{
        //    Bundle bundle = new Bundle("~/assets/v-css", new CssMinify());

        //    bundle.AddFile("~/assets/css/bootstrap.css");
        //    bundle.AddFile("~/assets/css/bootstrap-responsive.css");
        //    bundle.AddFile("~/assets/css/style.css");

        //    return bundle;
        //}

        //public Bundle EnableJSBootstrap()
        //{
        //    Bundle bundle = new Bundle("~/assets/v-js", new JsMinify());

        //    bundle.AddFile("~/assets/js/app.js");
        //    bundle.AddFile("~/assets/js/bootstrap.js");
        //    bundle.AddFile("~/assets/js/jquery.js");
        //    bundle.AddFile("~/assets/js/mask.js");

        //    return bundle;
        //}
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvcTesting
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

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
                new { controller = "Home", action = "Display", id = UrlParameter.Optional } // Parameter defaults
                // Parameter defaults
            );
            //routes.MapRoute(
            //    "Default",
            //    "{controller}/{action}/{name}/{id}",
            //    new { controller = "Home", action = "Display", name = UrlParameter.Optional, id = UrlParameter.Optional }
            //);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object src, EventArgs e)
        {
            if (Context.Session != null)
            {
                if (Context.Session.IsNewSession)
                {
                    string sCookieHeader = Request.Headers["Cookie"];
                    if ((null != sCookieHeader) && (sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    { 
                        Response.Redirect("/Home/About");
                    }
                }
            }
        }
    }
}
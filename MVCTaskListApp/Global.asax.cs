using MVCTaskListApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace MVCTaskListApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //This is needed if changes are made to database after created
            //Database.SetInitializer<OurDbContext>(new DropCreateDatabaseIfModelChanges<OurDbContext>());
            //Database.SetInitializer<DbTasks>(new DropCreateDatabaseIfModelChanges<DbTasks>());
        }
    }
}

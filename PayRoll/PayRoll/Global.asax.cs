using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PayRoll;
using PayRoll.Core.Model.Utility;

namespace PayRoll
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var ServerName = ConfigurationManager.AppSettings["ServerName"];
            var DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            var UserId = ConfigurationManager.AppSettings["UserId"];
            var Password = ConfigurationManager.AppSettings["Password"];


            string status = "Yes";

            AppDbConnection.ConnectionString = @"Data Source =" + ServerName +
                                                       "; Initial Catalog =" + DatabaseName +
                                                       "; User ID = " + UserId +
                                                       "; Password= " + Password;

            // If Database User and pass not exist

            //DatabaseConfiguration.ConnectionString = @"Data Source =" + ServerName +
            //                                      "; Initial Catalog =" + DatabaseName +
            //                                      ";Trusted_Connection=" + status + "";
            
         
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }
        protected void Session_End(object sender, EventArgs e)
        {

        }
    }
}

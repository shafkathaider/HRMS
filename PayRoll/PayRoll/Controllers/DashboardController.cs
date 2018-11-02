
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayRoll.Core.BLL.Manager;
using PayRoll.Core.Model.Utility;
using PayRoll.Core.Model.Utility.ActionFilters;

namespace PayRoll.Controllers
{
    [CheckSession]
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
 
        public ActionResult Index()
        {

            return View();
        }

       


    }
}
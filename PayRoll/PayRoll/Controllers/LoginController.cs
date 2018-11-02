using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PayRoll.Core.BLL.Manager;
using PayRoll.Core.Model.Utility;
using PayRoll.Core.Model.Utility.ActionFilters;
using PayRoll.License;

namespace PayRoll.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginManager _iLoginManager;
        public LoginController()
        {
            _iLoginManager = new LoginManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string employeeId, string password)
        {
            OrganizationInformation organization = new OrganizationInformation();
            
            var msg = _iLoginManager.DoLogin(employeeId, password);
            if (msg.MessageType == MessageTypes.Success)
            {
                CreateSession(employeeId);
            }
            else
            {
                Session["Session"] = null;
            }

            return Json(msg, JsonRequestBehavior.AllowGet);

        }

        private void CreateSession(string employeeId)
        {
            var data = _iLoginManager.GetUserSession(employeeId);
            AppSession appSession = new AppSession();
            if (data != null)
            {
                appSession.UserId = data.UserId;
                appSession.UserFullName = data.UserFullName;
                appSession.RoleId = data.RoleId;           
                Session["Session"] = appSession;
            }
            else
            {
                Session["Session"] = null;
            }

        }


        [HttpGet]
        [CheckSession]
        [ClearCache]
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

	}
}
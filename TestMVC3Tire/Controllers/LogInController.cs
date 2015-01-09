using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC3Tire.Models;

namespace TestMVC3Tire.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection, LogIn objLogIn)
        {
            DBaccessController DBAcccess = new DBaccessController();
            if ((objLogIn.UserName != "") && (objLogIn.Password != null))
            {
                try
                {
                    LogIn obj = new LogIn();
                    obj=DBAcccess.CheckLogIn(objLogIn);
                    ViewBag.ValSuccessMessage = "S";
                    Session["UserName"] = obj.UserName;

                    return RedirectToAction("../Contact/index");

                    //return RedirectToAction("Index", "Contact", new{ username: username});
                }
                catch (Exception Ex)
                {
                    return View(objLogIn);
                }
            }
            else
            {
                ViewBag.ValSuccessMessage = "F";
                return View(objLogIn);
            }
        }
    }
}

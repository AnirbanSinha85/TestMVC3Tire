using PRLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMVC3Tire.Controllers
{
    public class TestContactController : Controller
    {
        //
        // GET: /TestContact/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection, PRContact Con)
        {
            DBaccessController DBAcccess = new DBaccessController();
            if ((Con.FirstName != "") && (Con.FirstName != null))
            {
                try
                {
                    DBAcccess.SaveContact(Con);
                    ViewBag.ValSuccessMessage = "S";
                    return View();
                }
                catch (Exception Ex)
                {
                    return View(Con);
                }
            }
            else
            {
                ViewBag.ValSuccessMessage = "F";
                return View(Con);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC3Tire.Models;

namespace TestMVC3Tire.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "2 Model in a single page";
            dynamic mymodel = new ExpandoObject();
            mymodel.Contact = GetContact();
            mymodel.Mandate = GetMandate();
            return View(mymodel);
        }

        public List<Contact> GetContact()
        {
            DBaccessController DBAcccess = new DBaccessController();
            List<Contact> ListContact = DBAcccess.GetContactList();
            return ListContact;
        }

        public List<Mandate> GetMandate()
        {
             DBaccessController DBAcccess = new DBaccessController();
             List<Mandate> ListMandate = DBAcccess.GetMandateList();
             return ListMandate;
             
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC3Tire.Models;

namespace TestMVC3Tire.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
           // var UserName = Session["UserName"];

            ViewBag.UserName = Session["UserName"];

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection, Contact Con)
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

        //public ActionResult ShowList()
        //{
        //    DBaccessController DBAcccess = new DBaccessController();
        //    List<Contact> ListContact = DBAcccess.GetContactList();
        //    return View(ListContact);
        //}

        //public JsonResult ShowTableList(int id, String FilterField, String FilterValue)
        //{
        //    DBaccessController DBAcccess = new DBaccessController();
        //    List<Contact> ListContact = DBAcccess.GetContactList();

        //    //List<Contact> Customers = ReturnSelectiveRecord(id);
        //    //if ((FilterField != null) && (FilterField != "") && (FilterValue != null) && (FilterValue != ""))
        //    //{
        //    //    Customers = Customers.FindAll(x => x.FirstName == FilterValue);
        //    //}
        //    //var result = from r in Customers
        //    //             select new { r.FirstName, r.Middlename, r.LastName, r.EmailId, r.ContactReference, r.ContactID };
        //    return Json(ListContact, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult ShowList()
        {
            List<Contact> SelectedListContact = new List<Contact>();
            SelectedListContact = ReturnSelectiveRecord(0);
            ViewBag.PageValue = "0";
            ViewBag.UserName = Session["UserName"];
            return View(SelectedListContact);
        }

        public List<Contact> ReturnSelectiveRecord(int PageStart)
        {
            int pageSize = 2;

            PageStart = (PageStart * pageSize);

            DBaccessController DBAcccess = new DBaccessController();
            List<Contact> ListContact = DBAcccess.GetContactList();
            List<Contact> SelectedListContact = new List<Contact>();
            int MaxRange = PageStart + pageSize;
            if (MaxRange > (ListContact.Count() - 1))
            {
                MaxRange = ListContact.Count();
            }

            for (int i = PageStart; i < MaxRange; i++)
            {
                Contact pitem = new Contact();
                pitem = ListContact[i];
                SelectedListContact.Add(pitem);
            }
            return SelectedListContact;
        }

        public JsonResult ShowTableList(int id, String FilterField, String FilterValue)
        {
            List<Contact> Customers = ReturnSelectiveRecord(id);
            if ((FilterField != null) && (FilterField != "") && (FilterValue != null) && (FilterValue != ""))
            {
                Customers = Customers.FindAll(x => x.FirstName == FilterValue);
            }
            var result = from r in Customers
                         select new { r.FirstName, r.AddressLine1,r.PhoneNo, r.ContactID };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Edit(int id)
        {
            DBaccessController DBAcccess = new DBaccessController();
            Contact Con = DBAcccess.GetContact(id).FirstOrDefault();
            return View(Con);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection, Contact Con)
        {
            DBaccessController DBAcccess = new DBaccessController();
            DBAcccess.UpdateContact(Con);
            return RedirectToAction("ShowList");
        }
    }
}

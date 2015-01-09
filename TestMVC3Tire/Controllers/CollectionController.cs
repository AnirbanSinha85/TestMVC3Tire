using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TestMVC3Tire.Models;

namespace TestMVC3Tire.Controllers
{
    public class CollectionController : Controller
    {
        //
        // GET: /Collection/
        public ActionResult Index()
        {
            try
            {
                DBaccessController DBAcccess = new DBaccessController();
                TempData["ContactList"] = new SelectList(DBAcccess.GetContactList(), "ContactID", "FirstName");
                TempData["MandateList"] = new SelectList(DBAcccess.GetMandateList(), "MandateID", "MandateName");

                ViewBag.ddlContact = TempData["ContactList"];//new SelectList(DBAcccess.GetContactList(), "ContactID", "FirstName");
                ViewBag.ddlMandate = TempData["MandateList"];// new SelectList(DBAcccess.GetMandateList(), "MandateID", "MandateName");
                TempData.Keep("ContactList");
                TempData.Keep("MandateList");
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection, Collection objColl, string Command)
        {
            DBaccessController DBAcccess = new DBaccessController();
            ViewBag.ddlContact = new SelectList(DBAcccess.GetContactList(), "ContactID", "FirstName");
            ViewBag.ddlMandate = new SelectList(DBAcccess.GetMandateList(), "MandateID", "MandateName");

            List<Collection> objCollList = new List<Collection>();

            if (string.IsNullOrEmpty(Command))
            {
                objCollList = CreateList(objColl, formCollection);
            }

            if (Command == "SaveAll")
            {
                objCollList =(List<Collection>)TempData["CollectionList"];
                var xEle = new XElement("Collections",
               from emp in objCollList
               select new XElement("Collection",
                       new XAttribute("ContactID", emp.ContactID),
                        new XElement("ContactID", emp.ContactID),
                       new XElement("MandateID", emp.MandateID),
                       new XElement("CollectionAmount", emp.CollectionAmount),
                       new XElement("CollectionDate", emp.CollectionDate)
                     ));

                xEle.Save("D:\\employees.xml");
            }

            try
            {
                //DBAcccess.SaveMandate(man);
                ViewBag.ValSuccessMessage = "S";
                return View();
            }
            catch (Exception Ex)
            {
                return View(objColl);
            }

        }

        [HttpPost]
        public ActionResult SaveAll()
        {
            var button = "TEst";
            return Content(button);
        }

        public List<Collection> CreateList(Collection objColl, FormCollection formCollection)
        {
            var collDate = formCollection.Get("CollectionDate");

            List<Collection> CollList = new List<Collection>();

            var tempCollList = (List<Collection>)TempData["CollectionList"];
            if (tempCollList != null)
            {
                CollList = (List<Collection>)TempData["CollectionList"];
            }

            CollList.Add(objColl);
            TempData["CollectionList"] = CollList;
            TempData.Keep("CollectionList");

            return CollList;
        }
    }
}

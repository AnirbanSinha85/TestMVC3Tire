using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestMVC3Tire.Models;
using System.Linq;

namespace TestMVC3Tire.Controllers
{
    public class MandateController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                DBaccessController DBAcccess = new DBaccessController();
                ViewBag.ddlContact = new SelectList(DBAcccess.GetContactList(), "ContactID", "FirstName");
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        #region Save Mandate

        [HttpPost]
        public ActionResult Index(FormCollection formCollection, Mandate man)
        {
            DBaccessController DBAcccess = new DBaccessController();
            var ContactID = man.ContactID;
            var sal = formCollection.Get("ddlSalutation");

            man.Status = "InsertMandate";
            man.Salutation = sal;
            man.SalutationID = Convert.ToInt32(sal);

            ViewBag.ddlContact = new SelectList(DBAcccess.GetContactList(), "ContactID", "FirstName");

            if (!string.IsNullOrEmpty(man.MandateName))
            {
                try
                {
                    DBAcccess.SaveMandate(man);
                    ViewBag.ValSuccessMessage = "S";
                    //return View();
                    return RedirectToAction("ShowList");

                }
                catch (Exception Ex)
                {
                    return View(man);
                }
            }
            else
            {
                ViewBag.ValSuccessMessage = "F";
                return View(man);
            }
        }

        #endregion

        #region Get Mandate List 

        public ActionResult ShowList()
        {
            List<Mandate> SelectedListContact = new List<Mandate>();
            SelectedListContact = ReturnSelectiveRecord(0);
            ViewBag.PageValue = "0";
            ViewBag.fromDate = DateTime.Now.ToString("dd/MM/yyyy");
            return View(SelectedListContact);
        }

        public List<Mandate> ReturnSelectiveRecord(int PageStart)
        {
            int pageSize = 2;

            PageStart = (PageStart * pageSize);

            DBaccessController DBAcccess = new DBaccessController();
            List<Mandate> ListContact = DBAcccess.GetMandateList();
            List<Mandate> SelectedListContact = new List<Mandate>();
            int MaxRange = PageStart + pageSize;
            if (MaxRange > (ListContact.Count - 1))
            {
                MaxRange = ListContact.Count;
            }

            for (int i = PageStart; i < MaxRange; i++)
            {
                Mandate pitem = new Mandate();
                pitem = ListContact[i];
                SelectedListContact.Add(pitem);
            }
            return SelectedListContact;
        }

        public JsonResult ShowTableList(int id, String FilterField, String FilterValue)
        {
            List<Mandate> Customers = ReturnSelectiveRecord(id);
            if ((FilterField != null) && (FilterField != "") && (FilterValue != null) && (FilterValue != ""))
            {
                Customers = Customers.FindAll(x => x.MandateName == FilterValue);
            }
            var result = from r in Customers
                         select new {r.MandateName,r.SalutationName,r.ContactName,r.MandateID };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Mandate Edit Update

        public ActionResult Edit(int id)
        {
            DBaccessController DBAcccess = new DBaccessController();
            Mandate Con = DBAcccess.GetMandate(id).FirstOrDefault();
            ViewBag.ddlContact = new SelectList(DBAcccess.GetContactList(), "ContactID", "FirstName");
            return View(Con);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection, Mandate Con)
        {
            DBaccessController DBAcccess = new DBaccessController();
            DBAcccess.UpdateMandate(Con);
            return RedirectToAction("ShowList");
        }

        #endregion

       
    }
}

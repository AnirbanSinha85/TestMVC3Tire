﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC3Tire.Models;

namespace TestMVC3Tire.Controllers
{
    public class AddressController : Controller
    {
        //
        // GET: /Address/

        public ActionResult Index()
        {
            Address objcountrymodel = new Address();
            objcountrymodel.StateModel = GetAllState();
            objcountrymodel.FilteredCity = new SelectList(new List<City> { new City() { Id = 0, CityName = "Select City" } },"Id","CityName");

            return View(objcountrymodel);
        }

        [HttpPost]
        public ActionResult GetCityByStaeId(int stateid)
        {
            List<City> objcity = new List<City>();
            objcity = GetAllCity().Where(m => m.StateId == stateid).ToList();
            SelectList obgcity = new SelectList(objcity, "Id", "CityName", 0);
            return Json(obgcity);
        }

        // Collection for state
        public List<State> GetAllState()
        {
            List<State> objstate = new List<State>();
            objstate.Add(new State { Id = 0, StateName = "Select State" });
            objstate.Add(new State { Id = 1, StateName = "State 1" });
            objstate.Add(new State { Id = 2, StateName = "State 2" });
            objstate.Add(new State { Id = 3, StateName = "State 3" });
            objstate.Add(new State { Id = 4, StateName = "State 4" });
            return objstate;
        }

        //collection for city
        public List<City> GetAllCity()
        {
            List<City> objcity = new List<City>();
            objcity.Add(new City { Id = 1, StateId = 1, CityName = "City1-1" });
            objcity.Add(new City { Id = 2, StateId = 2, CityName = "City2-1" });
            objcity.Add(new City { Id = 3, StateId = 3, CityName = "City4-1" });
            objcity.Add(new City { Id = 4, StateId = 1, CityName = "City1-2" });
            objcity.Add(new City { Id = 5, StateId = 1, CityName = "City1-3" });
            objcity.Add(new City { Id = 6, StateId = 4, CityName = "City4-2" });
            return objcity;
        }

    }
}

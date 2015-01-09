using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMVC3Tire.Models
{
    public class Address
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a StateID")]
        public int Id { get; set; }

        public List<State> StateModel { get; set; }
        public SelectList FilteredCity { get; set; }

        //public Address()
        //{
        //    StateModel = new List<State>();
        //    FilteredCity = new SelectList(new List<City>(){new City() {Id=0,CityName="Select City"}});
        //}
    }

    public class CountryModel
    {
        public List<State> StateModel { get; set; }
        public SelectList FilteredCity { get; set; }
    }
    public class State
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a State")]
        public int Id { get; set; }
        public string StateName { get; set; }
    }
    public class City
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a City")]
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
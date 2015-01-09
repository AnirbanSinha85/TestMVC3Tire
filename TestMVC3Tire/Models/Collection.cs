using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMVC3Tire.Models
{
    public class Collection
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a contact")]
        public int ContactID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a Mandate")]
        public int MandateID { get; set; }

        public int CollectionAmount { get; set; }

        public DateTime CollectionDate { get; set; }

        public String Status { get; set; }
    }
}
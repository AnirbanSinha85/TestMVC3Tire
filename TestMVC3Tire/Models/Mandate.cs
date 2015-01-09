using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMVC3Tire.Models
{
    public class Mandate
    {
        //[RequiredSelect(ErrorMessage = "Please select a contact")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please Select a contact")]
        public int ContactID { get; set; }

        public int MandateID { get; set; }
        public int SalutationID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a salutation")]
        public String Salutation { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public String MandateName { get; set; }

        public String Status { get; set; }
        public String SalutationName { get; set; }
        public String ContactName { get; set; }

        public DateTime fromDate {get;set;}
        
    }
}
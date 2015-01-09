using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMVC3Tire.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please select a contact")]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        public String PhoneNo { get; set; }

        [Required(ErrorMessage = "AddressLine1 is required")]
        public String AddressLine1 { get; set; }

        public String Status { get; set; }
    }
}
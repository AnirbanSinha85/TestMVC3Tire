using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMVC3Tire.Models
{
    public class LogIn
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; set; }

        public String Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoAppJLT.Models
{
    public class Employee
    {
        //Auto Implemented Property
        [Required(ErrorMessage ="EmpId Is Mandatory field")]
        //[RegularExpression(@"^([0-9]{2,4})&", ErrorMessage ="Please enter EmpId as minimum 2 and maximum 4 digit")]
        public int? EmpId { get; set; }
        [Required(ErrorMessage = "EmpName Is Mandatory field")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Salary Is Mandatory field")]
        public decimal? Salary { get; set; }

    }
}
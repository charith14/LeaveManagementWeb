using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementWeb.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee Code")]
        [StringLength(20)]
        public string EmployeeCode { get; set; }

        
        [Display(Name = "Employee Name")]
        [StringLength(50)]
        public string EmployeeName { get; set; }


        [Display(Name = "Supervisor Code")]
        [StringLength(20)]
        public string SupervisorCode { get; set; }

        [Display(Name = "Leave Package")]
        [StringLength(20)]
        public string LeavePackage { get; set; } // Shop and office , Office or Wages Board

        //[ForeignKey("SupervisorCode")]
        //public virtual Employee EmployeeID { get; set; }
    }
}
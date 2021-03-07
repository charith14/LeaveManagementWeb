using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeaveManagementWeb.Models
{
    public class LeaveEntry
    {

        [Key, Column(Order = 0)]
        [Editable(false)]
        [Required(ErrorMessage = "Employee Code is required.")]
        public string EmployeeCode { get; set; }


        public string CheckByName { get; set; } 

        [Key, Column(Order = 1)]
        public string LeaveTypeId { get; set; }

        [Key, Column(Order = 2)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckDate { get; set; } 

        public string Status { get; set; } 


        public string CommentsEmployee { get; set; } 


        public string CommentsApprover { get; set; } 


        public int AutoNumber { get; set; }

        [ForeignKey("EmployeeCode"), Column(Order = 0)]
        public virtual Employee Employee1 { get; set; }
       

        [ForeignKey("CheckByName"), Column(Order = 1)]
        public virtual Employee Employee2 { get; set; }
        

        [ForeignKey("LeaveTypeId"), Column(Order = 2)]
        public virtual LeaveType LeaveTypeCode { get; set; }

    }
}
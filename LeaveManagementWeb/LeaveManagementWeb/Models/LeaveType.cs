using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementWeb.Models
{
    public class LeaveType
    {
        [Key]
        public string LeaveTypeCode { get; set; }

        public string Description { get; set; }
    }
}
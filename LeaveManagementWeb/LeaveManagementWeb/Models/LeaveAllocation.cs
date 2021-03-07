﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeaveManagementWeb.Models
{
    public class LeaveAllocation
    {
        [Key, Column(Order = 0)]
        [StringLength(20)]
        [ForeignKey("Employee")]
        public string EmployeeID { get; set; }

        [Key, Column(Order = 1)]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        public string LeaveType { get; set; }

        public int EntitledAmount { get; set; }

        public int UtilizedAmount { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LeaveType LeaveTypeCode { get; set; }
    }
}
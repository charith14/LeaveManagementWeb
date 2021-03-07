using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeaveManagementWeb.Models
{
    public class LeaveContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveAllocation> LeaveAlloations { get; set; }
        public DbSet<LeaveEntry> LeaveEntries { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
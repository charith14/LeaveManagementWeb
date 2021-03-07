using LeaveManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementWeb.Controllers
{
    public class HomeController : Controller
    {
        private LeaveContext context = new LeaveContext();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult LeaveApprove()
        {
            // have to display all leave applications for this Employee ID as the supervisor ID
            List<LeaveEntry> leaveEntries = context.LeaveEntries.Where(x => x.Employee1.SupervisorCode == System.Web.HttpContext.Current.User.Identity.Name).ToList();
            return View(leaveEntries);
        }

        public ActionResult LeaveApply()
        {
            ViewBag.empID = ViewBag.empId;
            return View();
        }

       
        [HttpPost]
        public ActionResult LeaveApply(LeaveEntry leaveEntry)
        {


            if (ModelState.IsValid)
            {
                try
                {


                    context.LeaveEntries.Add(leaveEntry);
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.Write("Error when entering the data" + e.Message);
                    ModelState.AddModelError("", "Can't make your request. May be you have get all the leaves which are applicable 1");
                }
                return RedirectToAction("LeaveApply");
            }
            else
            {
                ModelState.AddModelError("", "Can't make your request. May be you have get all the leaves which are applicable 2");
                return View();
            }

        }
   

        public bool isValidateLeave(string empCode, string leaveCode)
        {

            //check all the fields are filled and ok with the business logic
            bool validate = false;
            LeaveAllocation leaveAllocation = context.LeaveAlloations.Where(x => x.EmployeeID == empCode && x.LeaveTypeCode.ToString() == leaveCode).SingleOrDefault();

            if (leaveAllocation.UtilizedAmount < leaveAllocation.EntitledAmount)
            {
                //all the leaves has been get
                validate = true;

            }


            return validate;
        }

        //  [Authorize]
        public ActionResult approve(string empId, string leaveTypeId, DateTime reqDate)
        {
            LeaveEntry lEntry = context.LeaveEntries.Where(x => x.EmployeeCode == empId && x.LeaveTypeId == leaveTypeId && x.RequestedDate == reqDate).SingleOrDefault();
            return View(lEntry);
        }


        [HttpPost]
        [Authorize]
        public ActionResult approve(string empId, string leaveTypeId, DateTime reqDate, LeaveEntry leaveEntry)
        {
            LeaveEntry lEntry = context.LeaveEntries.Where(x => x.EmployeeCode == empId && x.LeaveTypeId == leaveTypeId && x.RequestedDate == reqDate).SingleOrDefault();

            if (ModelState.IsValid)
            {

                //update
                lEntry.EmployeeCode = leaveEntry.EmployeeCode;
                lEntry.LeaveTypeCode = leaveEntry.LeaveTypeCode;
                lEntry.RequestedDate = leaveEntry.RequestedDate;
                lEntry.CheckByName = leaveEntry.CheckByName;
                lEntry.CheckDate = DateTime.Now;
                lEntry.Status = "Approved";
                lEntry.CommentsEmployee = leaveEntry.CommentsEmployee;
                lEntry.CommentsApprover = leaveEntry.CommentsApprover;
                lEntry.AutoNumber = leaveEntry.AutoNumber;
                context.SaveChanges();

                return RedirectToAction("LeaveApprove");

            }
            else
            {
                return View(lEntry);
            }


        }
    }
}
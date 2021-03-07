namespace LeaveManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeCode = c.String(nullable: false, maxLength: 20),
                        EmployeeName = c.String(maxLength: 50),
                        SupervisorCode = c.String(maxLength: 20),
                        LeavePackage = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.EmployeeCode);
            
            CreateTable(
                "dbo.LeaveAllocations",
                c => new
                    {
                        EmployeeID = c.String(nullable: false, maxLength: 20),
                        Year = c.DateTime(nullable: false),
                        LeaveType = c.String(),
                        EntitledAmount = c.Int(nullable: false),
                        UtilizedAmount = c.Int(nullable: false),
                        LeaveTypeCode_LeaveTypeCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EmployeeID, t.Year })
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeCode_LeaveTypeCode)
                .Index(t => t.EmployeeID)
                .Index(t => t.LeaveTypeCode_LeaveTypeCode);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        LeaveTypeCode = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LeaveTypeCode);
            
            CreateTable(
                "dbo.LeaveEntries",
                c => new
                    {
                        EmployeeCode = c.String(nullable: false, maxLength: 20),
                        LeaveTypeId = c.String(nullable: false, maxLength: 128),
                        RequestedDate = c.DateTime(nullable: false),
                        CheckDate = c.DateTime(nullable: false),
                        CheckByName = c.String(maxLength: 20),
                        Status = c.String(),
                        CommentsEmployee = c.String(),
                        CommentsApprover = c.String(),
                        AutoNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeCode, t.LeaveTypeId, t.RequestedDate })
                .ForeignKey("dbo.Employees", t => t.EmployeeCode, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.CheckByName)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeCode)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.CheckByName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveEntries", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveEntries", "CheckByName", "dbo.Employees");
            DropForeignKey("dbo.LeaveEntries", "EmployeeCode", "dbo.Employees");
            DropForeignKey("dbo.LeaveAllocations", "LeaveTypeCode_LeaveTypeCode", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveAllocations", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.LeaveEntries", new[] { "CheckByName" });
            DropIndex("dbo.LeaveEntries", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveEntries", new[] { "EmployeeCode" });
            DropIndex("dbo.LeaveAllocations", new[] { "LeaveTypeCode_LeaveTypeCode" });
            DropIndex("dbo.LeaveAllocations", new[] { "EmployeeID" });
            DropTable("dbo.LeaveEntries");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.LeaveAllocations");
            DropTable("dbo.Employees");
        }
    }
}

namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaffModule_change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            AddColumn("dbo.Staffs", "StaffIsHeadOffice", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "DepartmentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Staffs", "DepartmentId");
            AddForeignKey("dbo.Staffs", "DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Positions", "DepartmentId");
            DropColumn("dbo.Staffs", "StaffType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "StaffType", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "DepartmentId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Staffs", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Staffs", new[] { "DepartmentId" });
            DropColumn("dbo.Staffs", "DepartmentId");
            DropColumn("dbo.Staffs", "StaffIsHeadOffice");
            CreateIndex("dbo.Positions", "DepartmentId");
            AddForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}

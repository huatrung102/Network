namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "LocationId", "dbo.Locations");
            DropIndex("dbo.Staffs", new[] { "LocationId" });
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Guid(nullable: false),
                        DepartmentName = c.String(maxLength: 50),
                        LocationId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            AddColumn("dbo.Positions", "PositionIsLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.Positions", "DepartmentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Positions", "DepartmentId");
            AddForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Staffs", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "LocationId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "LocationId", "dbo.Locations");
            DropIndex("dbo.Departments", new[] { "LocationId" });
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            DropColumn("dbo.Positions", "DepartmentId");
            DropColumn("dbo.Positions", "PositionIsLeader");
            DropTable("dbo.Departments");
            CreateIndex("dbo.Staffs", "LocationId");
            AddForeignKey("dbo.Staffs", "LocationId", "dbo.Locations", "LocationId");
        }
    }
}

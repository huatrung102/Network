namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Location_LocationId", "dbo.Locations");
            DropIndex("dbo.Departments", new[] { "Location_LocationId" });
            DropColumn("dbo.Departments", "Location_LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Location_LocationId", c => c.Guid());
            CreateIndex("dbo.Departments", "Location_LocationId");
            AddForeignKey("dbo.Departments", "Location_LocationId", "dbo.Locations", "LocationId");
        }
    }
}

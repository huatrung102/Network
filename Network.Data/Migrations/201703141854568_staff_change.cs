namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staff_change : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Staffs", new[] { "Location_LocationId" });
            RenameColumn(table: "dbo.Staffs", name: "Location_LocationId", newName: "LocationId");
            AlterColumn("dbo.Staffs", "LocationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Staffs", "LocationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Staffs", new[] { "LocationId" });
            AlterColumn("dbo.Staffs", "LocationId", c => c.Guid());
            RenameColumn(table: "dbo.Staffs", name: "LocationId", newName: "Location_LocationId");
            CreateIndex("dbo.Staffs", "Location_LocationId");
        }
    }
}

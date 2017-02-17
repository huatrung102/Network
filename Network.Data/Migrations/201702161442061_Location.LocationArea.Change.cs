namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationLocationAreaChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "LocationArea", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "LocationArea", c => c.String(maxLength: 50));
        }
    }
}

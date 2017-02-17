namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationLocationTaxToFaxChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "LocationFax", c => c.String(maxLength: 50));
            DropColumn("dbo.Locations", "LocationTax");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "LocationTax", c => c.String(maxLength: 50));
            DropColumn("dbo.Locations", "LocationFax");
        }
    }
}

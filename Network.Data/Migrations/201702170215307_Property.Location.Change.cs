namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyLocationChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "LocationAreaM2", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "LocationAreaM2");
        }
    }
}

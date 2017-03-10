namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_change1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contracts", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Contracts", new[] { "DocumentId" });
            AddColumn("dbo.Contracts", "LocationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Contracts", "LocationId");
            AddForeignKey("dbo.Contracts", "LocationId", "dbo.Locations", "LocationId");
            DropColumn("dbo.Contracts", "DocumentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "DocumentId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Contracts", "LocationId", "dbo.Locations");
            DropIndex("dbo.Contracts", new[] { "LocationId" });
            DropColumn("dbo.Contracts", "LocationId");
            CreateIndex("dbo.Contracts", "DocumentId");
            AddForeignKey("dbo.Contracts", "DocumentId", "dbo.Documents", "DocumentId");
        }
    }
}

namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person_RefPartnerId_delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "RefPartnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "RefPartnerId", c => c.Guid(nullable: false));
        }
    }
}

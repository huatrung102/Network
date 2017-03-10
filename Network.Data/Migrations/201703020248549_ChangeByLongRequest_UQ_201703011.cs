namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeByLongRequest_UQ_201703011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "DocumentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "DocumentType");
        }
    }
}

namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Document_DocumentType_remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Documents", "DocumentType");
            AddColumn("dbo.DocumentFileAttachments", "DocumentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "DocumentType", c => c.Int(nullable: false));
        }
    }
}

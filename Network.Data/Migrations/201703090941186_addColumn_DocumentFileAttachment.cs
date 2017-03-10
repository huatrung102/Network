namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn_DocumentFileAttachment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentFileAttachments", "FileAttachmentValidDate", c => c.String(maxLength: 4000));
            AddColumn("dbo.DocumentFileAttachments", "FileAttachmentStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.DocumentFileAttachments", "FileAttachmentGroup");
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentFileAttachments", "FileAttachmentStatus");
            DropColumn("dbo.DocumentFileAttachments", "FileAttachmentValidDate");
        }
    }
}

namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changeColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileAttachments", "DocumentHP_DocumentHPId", "dbo.DocumentHPs");
            DropIndex("dbo.FileAttachments", new[] { "DocumentHP_DocumentHPId" });
            AddColumn("dbo.DocumentFileAttachments", "FileName", c => c.String(maxLength: 200));
            AddColumn("dbo.DocumentHPFileAttachments", "FileAttachmentName", c => c.String(maxLength: 200));
            DropColumn("dbo.FileAttachments", "FileAttachmentName");
            DropColumn("dbo.FileAttachments", "FileAttachmenGroup");
            DropColumn("dbo.FileAttachments", "DocumentHP_DocumentHPId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileAttachments", "DocumentHP_DocumentHPId", c => c.Guid());
            AddColumn("dbo.FileAttachments", "FileAttachmenGroup", c => c.Int(nullable: false));
            AddColumn("dbo.FileAttachments", "FileAttachmentName", c => c.String(maxLength: 200));
            DropColumn("dbo.DocumentHPFileAttachments", "FileAttachmentName");
            DropColumn("dbo.DocumentFileAttachments", "FileName");
            CreateIndex("dbo.FileAttachments", "DocumentHP_DocumentHPId");
            AddForeignKey("dbo.FileAttachments", "DocumentHP_DocumentHPId", "dbo.DocumentHPs", "DocumentHPId");
        }
    }
}

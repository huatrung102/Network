namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changeColumn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractFileAttachments", "FileName", c => c.String(maxLength: 200));
            AddColumn("dbo.ContractFileAttachments", "FileAttachmentValidDate", c => c.String(maxLength: 4000));
            AddColumn("dbo.ContractFileAttachments", "FileAttachmentInvalidDate", c => c.String(maxLength: 4000));
            AddColumn("dbo.ContractFileAttachments", "FileAttachmentStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContractFileAttachments", "ContractType", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "ContractSchedulePayment", c => c.Int(nullable: false));
            DropColumn("dbo.ContractFileAttachments", "FileAttachmentGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContractFileAttachments", "FileAttachmentGroup", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contracts", "ContractSchedulePayment", c => c.Short(nullable: false));
            DropColumn("dbo.ContractFileAttachments", "ContractType");
            DropColumn("dbo.ContractFileAttachments", "FileAttachmentStatus");
            DropColumn("dbo.ContractFileAttachments", "FileAttachmentInvalidDate");
            DropColumn("dbo.ContractFileAttachments", "FileAttachmentValidDate");
            DropColumn("dbo.ContractFileAttachments", "FileName");
        }
    }
}

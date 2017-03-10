namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changeColumn2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContractFileAttachments", "FileAttachmentValidDate", c => c.String(maxLength: 25));
            AlterColumn("dbo.ContractFileAttachments", "FileAttachmentInvalidDate", c => c.String(maxLength: 25));
            AlterColumn("dbo.Contracts", "ContractDeposit", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "ContractDeposit", c => c.Single(nullable: false));
            AlterColumn("dbo.ContractFileAttachments", "FileAttachmentInvalidDate", c => c.String(maxLength: 4000));
            AlterColumn("dbo.ContractFileAttachments", "FileAttachmentValidDate", c => c.String(maxLength: 4000));
        }
    }
}

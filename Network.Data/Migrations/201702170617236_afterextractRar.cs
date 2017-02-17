namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterextractRar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileAttachments", "FileAttachmenGroup", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileAttachments", "FileAttachmenGroup");
        }
    }
}

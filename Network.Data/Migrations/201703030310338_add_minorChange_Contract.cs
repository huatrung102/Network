namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_minorChange_Contract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "ContractSignedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contracts", "ContractSigned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "ContractSigned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contracts", "ContractSignedDate");
        }
    }
}

namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_minorChange_Contract1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "ContractBalance", c => c.Single(nullable: false));
            AddColumn("dbo.Contracts", "ContractIsTax", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "ContractIsTax");
            DropColumn("dbo.Contracts", "ContractBalance");
        }
    }
}

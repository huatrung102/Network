namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeByLongRequest_UQ_20170301 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Partners", "PersonId", "dbo.People");
            DropIndex("dbo.Partners", new[] { "PersonId" });
            AddColumn("dbo.Contracts", "ContractName", c => c.String(maxLength: 4000));
            AddColumn("dbo.Contracts", "ContractNumber", c => c.String(maxLength: 4000));
            AddColumn("dbo.Contracts", "ContractSigned", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contracts", "ContractConditionTermEnd", c => c.Short(nullable: false));
            AddColumn("dbo.Contracts", "ContractConditionExtension", c => c.Short(nullable: false));
            AddColumn("dbo.Locations", "LocationType", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "PositionGroup", c => c.Int(nullable: false));
            AddColumn("dbo.Partners", "PartnerRepresentation", c => c.String(maxLength: 50));
            AddColumn("dbo.Partners", "PartnerPersonAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.Partners", "PartnerPersonPhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Partners", "PartnerPersonName", c => c.String(maxLength: 50));
            DropColumn("dbo.Partners", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Partners", "PersonId", c => c.Guid());
            DropColumn("dbo.Partners", "PartnerPersonName");
            DropColumn("dbo.Partners", "PartnerPersonPhone");
            DropColumn("dbo.Partners", "PartnerPersonAddress");
            DropColumn("dbo.Partners", "PartnerRepresentation");
            DropColumn("dbo.Positions", "PositionGroup");
            DropColumn("dbo.Locations", "LocationType");
            DropColumn("dbo.Contracts", "ContractConditionExtension");
            DropColumn("dbo.Contracts", "ContractConditionTermEnd");
            DropColumn("dbo.Contracts", "ContractSigned");
            DropColumn("dbo.Contracts", "ContractNumber");
            DropColumn("dbo.Contracts", "ContractName");
            CreateIndex("dbo.Partners", "PersonId");
            AddForeignKey("dbo.Partners", "PersonId", "dbo.People", "PersonId");
        }
    }
}

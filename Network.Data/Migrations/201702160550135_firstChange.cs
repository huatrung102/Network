namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Guid(nullable: false),
                        PartnerId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        ContractDeposit = c.Single(nullable: false),
                        ContractMoneyType = c.Int(nullable: false),
                        ContractValidDate = c.DateTime(nullable: false),
                        ContractInvalidDate = c.DateTime(),
                        ContractStatus = c.Int(nullable: false),
                        ContractSchedulePayment = c.Short(nullable: false),
                        IntegrityPlanId = c.Guid(nullable: false),
                        ECMId = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.ECMs", t => t.ECMId)
                .ForeignKey("dbo.IntegrityPlans", t => t.IntegrityPlanId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .Index(t => t.PartnerId)
                .Index(t => t.DocumentId)
                .Index(t => t.IntegrityPlanId, unique: true, name: "IntegrityPlanIndex")
                .Index(t => t.ECMId);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        CostId = c.Guid(nullable: false),
                        ContractId = c.Guid(nullable: false),
                        CostOfMonth = c.Int(nullable: false),
                        CostValue = c.Single(nullable: false),
                        CostExchangeRate = c.Single(),
                        CostOther = c.Single(),
                        CostTax = c.Single(),
                        CostBalance = c.Single(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CostId, t.ContractId })
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                        DocumentNumber = c.String(nullable: false, maxLength: 25),
                        DocumentDescription = c.String(maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Guid(nullable: false),
                        LocationName = c.String(maxLength: 50),
                        LocationCode = c.String(maxLength: 3),
                        LocationParentCode = c.String(maxLength: 3),
                        LocationAddress = c.String(maxLength: 300),
                        LocationPhone = c.String(maxLength: 50),
                        LocationTax = c.String(maxLength: 50),
                        LocationArea = c.String(maxLength: 50),
                        CoordinateX = c.Single(),
                        CoordinateY = c.Single(),
                        LocationDescription = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .Index(t => t.LocationCode, unique: true, name: "LocationCodeIndex");
            
            CreateTable(
                "dbo.FileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        FileAttachmentName = c.String(maxLength: 200),
                        Content = c.Binary(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Location_LocationId = c.Guid(),
                        Contract_ContractId = c.Guid(),
                        IntegrityPlan_IntegrityPlanId = c.Guid(),
                    })
                .PrimaryKey(t => t.FileAttachmentId)
                .ForeignKey("dbo.Locations", t => t.Location_LocationId)
                .ForeignKey("dbo.Contracts", t => t.Contract_ContractId)
                .ForeignKey("dbo.IntegrityPlans", t => t.IntegrityPlan_IntegrityPlanId)
                .Index(t => t.Location_LocationId)
                .Index(t => t.Contract_ContractId)
                .Index(t => t.IntegrityPlan_IntegrityPlanId);
            
            CreateTable(
                "dbo.ECMs",
                c => new
                    {
                        ECMId = c.Guid(nullable: false),
                        ECMLink = c.String(maxLength: 4000),
                        ECMName = c.String(maxLength: 4000),
                        ECMStatus = c.Short(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ECMId);
            
            CreateTable(
                "dbo.IntegrityPlans",
                c => new
                    {
                        IntegrityPlanId = c.Guid(nullable: false),
                        IntegrityPlanType = c.Int(nullable: false),
                        IntegrityPlanDescription = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IntegrityPlanId);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        PartnerId = c.Guid(nullable: false),
                        PartnerName = c.String(maxLength: 50),
                        PartnerPhone = c.String(maxLength: 50),
                        PersonId = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartnerId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        PersonName = c.String(maxLength: 50),
                        PersonPhone = c.String(maxLength: 50),
                        PersonPosition = c.String(maxLength: 50),
                        PersonDescription = c.String(maxLength: 100),
                        PersonType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partners", "PersonId", "dbo.People");
            DropForeignKey("dbo.Contracts", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Contracts", "IntegrityPlanId", "dbo.IntegrityPlans");
            DropForeignKey("dbo.FileAttachments", "IntegrityPlan_IntegrityPlanId", "dbo.IntegrityPlans");
            DropForeignKey("dbo.FileAttachments", "Contract_ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ECMId", "dbo.ECMs");
            DropForeignKey("dbo.Documents", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.FileAttachments", "Location_LocationId", "dbo.Locations");
            DropForeignKey("dbo.Contracts", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Costs", "ContractId", "dbo.Contracts");
            DropIndex("dbo.Partners", new[] { "PersonId" });
            DropIndex("dbo.FileAttachments", new[] { "IntegrityPlan_IntegrityPlanId" });
            DropIndex("dbo.FileAttachments", new[] { "Contract_ContractId" });
            DropIndex("dbo.FileAttachments", new[] { "Location_LocationId" });
            DropIndex("dbo.Locations", "LocationCodeIndex");
            DropIndex("dbo.Documents", new[] { "LocationId" });
            DropIndex("dbo.Costs", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "ECMId" });
            DropIndex("dbo.Contracts", "IntegrityPlanIndex");
            DropIndex("dbo.Contracts", new[] { "DocumentId" });
            DropIndex("dbo.Contracts", new[] { "PartnerId" });
            DropTable("dbo.People");
            DropTable("dbo.Partners");
            DropTable("dbo.IntegrityPlans");
            DropTable("dbo.ECMs");
            DropTable("dbo.FileAttachments");
            DropTable("dbo.Locations");
            DropTable("dbo.Documents");
            DropTable("dbo.Costs");
            DropTable("dbo.Contracts");
        }
    }
}

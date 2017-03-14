namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractFileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        ContractId = c.Guid(nullable: false),
                        FileName = c.String(maxLength: 200),
                        FileAttachmentValidDate = c.String(maxLength: 25),
                        FileAttachmentInvalidDate = c.String(maxLength: 25),
                        FileAttachmentStatus = c.Boolean(nullable: false),
                        ContractType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileAttachmentId, t.ContractId })
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .ForeignKey("dbo.FileAttachments", t => t.FileAttachmentId)
                .Index(t => t.FileAttachmentId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Guid(nullable: false),
                        PartnerId = c.Guid(nullable: false),
                        ContractName = c.String(maxLength: 200),
                        ContractNumber = c.String(maxLength: 200),
                        LocationId = c.Guid(nullable: false),
                        ContractDeposit = c.Short(nullable: false),
                        ContractMoneyType = c.Int(nullable: false),
                        ContractBalance = c.Single(nullable: false),
                        ContractIsTax = c.Boolean(nullable: false),
                        ContractValidDate = c.DateTime(nullable: false),
                        ContractInvalidDate = c.DateTime(),
                        ContractFirstPayDate = c.DateTime(),
                        ContractSignedDate = c.DateTime(nullable: false),
                        ContractStatus = c.Int(nullable: false),
                        ContractSchedulePayment = c.Int(nullable: false),
                        IntegrityPlanType = c.Int(nullable: false),
                        ContractConditionTermEnd = c.Short(nullable: false),
                        ContractConditionExtension = c.Short(nullable: false),
                        ECMId = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        PartnerHP_PartnerHPId = c.Guid(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.ECMs", t => t.ECMId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.PartnerHPs", t => t.PartnerHP_PartnerHPId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .Index(t => t.PartnerId)
                .Index(t => t.LocationId)
                .Index(t => t.ECMId)
                .Index(t => t.PartnerHP_PartnerHPId);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        CostId = c.Guid(nullable: false),
                        ContractId = c.Guid(nullable: false),
                        CostOfMonth = c.Short(nullable: false),
                        CostOfYear = c.Short(nullable: false),
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
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Guid(nullable: false),
                        LocationName = c.String(maxLength: 50),
                        LocationCode = c.String(maxLength: 3),
                        LocationParentCode = c.String(maxLength: 3),
                        LocationAddress = c.String(maxLength: 300),
                        LocationPhone = c.String(maxLength: 50),
                        LocationFax = c.String(maxLength: 50),
                        LocationArea = c.Int(nullable: false),
                        LocationAreaM2 = c.Single(),
                        LocationFrontSpace = c.Single(),
                        LocationPoint = c.Geography(),
                        LocationDescription = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .Index(t => t.LocationCode, unique: true, name: "LocationCodeIndex");
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Guid(nullable: false),
                        DepartmentName = c.String(maxLength: 50),
                        DepartmentGroup = c.Int(nullable: false),
                       
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                       
                    })
                .PrimaryKey(t => t.DepartmentId)
               ;
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Guid(nullable: false),
                        StaffName = c.String(maxLength: 50),
                        StaffPhone = c.String(maxLength: 50),
                        StaffEmail = c.String(maxLength: 50),
                        StaffIsHeadOffice = c.Boolean(nullable: false),
                        DepartmentId = c.Guid(nullable: false),
                        PositionId = c.Guid(nullable: false),
                        StaffCount = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Location_LocationId = c.Guid(),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .ForeignKey("dbo.Locations", t => t.Location_LocationId)
                .Index(t => t.StaffEmail, unique: true, name: "StaffEmailIndex")
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId)
                .Index(t => t.Location_LocationId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Guid(nullable: false),
                        PositionName = c.String(maxLength: 50),
                        PositionIsLeader = c.Boolean(nullable: false),
                        PositionCode = c.Int(),
                        PositionParentCode = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.LocationFileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileAttachmentId, t.LocationId })
                .ForeignKey("dbo.FileAttachments", t => t.FileAttachmentId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.FileAttachmentId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.FileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        Content = c.Binary(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FileAttachmentId);
            
            CreateTable(
                "dbo.DocumentFileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        FileName = c.String(maxLength: 200),
                        FileAttachmentValidDate = c.String(maxLength: 20),
                        FileAttachmentStatus = c.Boolean(nullable: false),
                        DocumentType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileAttachmentId, t.DocumentId })
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.FileAttachments", t => t.FileAttachmentId)
                .Index(t => t.FileAttachmentId)
                .Index(t => t.DocumentId);
            
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
                "dbo.DocumentHPFileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        DocumentHPId = c.Guid(nullable: false),
                        FileAttachmentName = c.String(maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileAttachmentId, t.DocumentHPId })
                .ForeignKey("dbo.DocumentHPs", t => t.DocumentHPId)
                .ForeignKey("dbo.FileAttachments", t => t.FileAttachmentId)
                .Index(t => t.FileAttachmentId)
                .Index(t => t.DocumentHPId);
            
            CreateTable(
                "dbo.DocumentHPs",
                c => new
                    {
                        DocumentHPId = c.Guid(nullable: false),
                        LocationHPId = c.Guid(nullable: false),
                        DocumentHPName = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentHPId)
                .ForeignKey("dbo.LocationHPs", t => t.LocationHPId)
                .Index(t => t.LocationHPId);
            
            CreateTable(
                "dbo.DocumentPartnerHPs",
                c => new
                    {
                        PartnerHPId = c.Guid(nullable: false),
                        DocumentHPId = c.Guid(nullable: false),
                        DocumentPartnerHpType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerHPId, t.DocumentHPId })
                .ForeignKey("dbo.DocumentHPs", t => t.DocumentHPId)
                .ForeignKey("dbo.PartnerHPs", t => t.PartnerHPId)
                .Index(t => t.PartnerHPId)
                .Index(t => t.DocumentHPId);
            
            CreateTable(
                "dbo.PartnerHPs",
                c => new
                    {
                        PartnerHPId = c.Guid(nullable: false),
                        PartnerHPName = c.String(maxLength: 50),
                        PartnerHPPhone = c.String(maxLength: 50),
                        PersonId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartnerHPId)
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
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.LocationHPs",
                c => new
                    {
                        LocationHPId = c.Guid(nullable: false),
                        LocationHPName = c.String(maxLength: 50),
                        LocationHPAddress = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        District_DistrictId = c.Short(),
                        Province_ProvinceId = c.Short(),
                    })
                .PrimaryKey(t => t.LocationHPId)
                .ForeignKey("dbo.Districts", t => t.District_DistrictId)
                .ForeignKey("dbo.Provinces", t => t.Province_ProvinceId)
                .Index(t => t.District_DistrictId)
                .Index(t => t.Province_ProvinceId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Short(nullable: false, identity: true),
                        DistrictName = c.String(maxLength: 50),
                        ProvinceId = c.Short(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Short(nullable: false, identity: true),
                        ProvinceName = c.String(maxLength: 50),
                        ProvinceOrder = c.Short(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.LocationHPFileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Guid(nullable: false),
                        LocationHPId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileAttachmentId, t.LocationHPId })
                .ForeignKey("dbo.FileAttachments", t => t.FileAttachmentId)
                .ForeignKey("dbo.LocationHPs", t => t.LocationHPId)
                .Index(t => t.FileAttachmentId)
                .Index(t => t.LocationHPId);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        PartnerId = c.Guid(nullable: false),
                        PartnerRepresentation = c.String(maxLength: 50),
                        PartnerName = c.String(maxLength: 50),
                        PartnerPhone = c.String(maxLength: 50),
                        PartnerType = c.Int(nullable: false),
                        PartnerPersonAddress = c.String(maxLength: 50),
                        PartnerPersonPhone = c.String(maxLength: 20),
                        PartnerPersonName = c.String(maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractFileAttachments", "FileAttachmentId", "dbo.FileAttachments");
            DropForeignKey("dbo.ContractFileAttachments", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Staffs", "Location_LocationId", "dbo.Locations");
            DropForeignKey("dbo.LocationFileAttachments", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.LocationFileAttachments", "FileAttachmentId", "dbo.FileAttachments");
            DropForeignKey("dbo.LocationHPFileAttachments", "LocationHPId", "dbo.LocationHPs");
            DropForeignKey("dbo.LocationHPFileAttachments", "FileAttachmentId", "dbo.FileAttachments");
            DropForeignKey("dbo.DocumentHPFileAttachments", "FileAttachmentId", "dbo.FileAttachments");
            DropForeignKey("dbo.DocumentHPFileAttachments", "DocumentHPId", "dbo.DocumentHPs");
            DropForeignKey("dbo.DocumentHPs", "LocationHPId", "dbo.LocationHPs");
            DropForeignKey("dbo.LocationHPs", "Province_ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.LocationHPs", "District_DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.DocumentPartnerHPs", "PartnerHPId", "dbo.PartnerHPs");
            DropForeignKey("dbo.PartnerHPs", "PersonId", "dbo.People");
            DropForeignKey("dbo.Contracts", "PartnerHP_PartnerHPId", "dbo.PartnerHPs");
            DropForeignKey("dbo.DocumentPartnerHPs", "DocumentHPId", "dbo.DocumentHPs");
            DropForeignKey("dbo.DocumentFileAttachments", "FileAttachmentId", "dbo.FileAttachments");
            DropForeignKey("dbo.DocumentFileAttachments", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Staffs", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Staffs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Location_LocationId1", "dbo.Locations");
            DropForeignKey("dbo.Contracts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Contracts", "ECMId", "dbo.ECMs");
            DropForeignKey("dbo.Costs", "ContractId", "dbo.Contracts");
            DropIndex("dbo.LocationHPFileAttachments", new[] { "LocationHPId" });
            DropIndex("dbo.LocationHPFileAttachments", new[] { "FileAttachmentId" });
            DropIndex("dbo.Districts", new[] { "ProvinceId" });
            DropIndex("dbo.LocationHPs", new[] { "Province_ProvinceId" });
            DropIndex("dbo.LocationHPs", new[] { "District_DistrictId" });
            DropIndex("dbo.PartnerHPs", new[] { "PersonId" });
            DropIndex("dbo.DocumentPartnerHPs", new[] { "DocumentHPId" });
            DropIndex("dbo.DocumentPartnerHPs", new[] { "PartnerHPId" });
            DropIndex("dbo.DocumentHPs", new[] { "LocationHPId" });
            DropIndex("dbo.DocumentHPFileAttachments", new[] { "DocumentHPId" });
            DropIndex("dbo.DocumentHPFileAttachments", new[] { "FileAttachmentId" });
            DropIndex("dbo.Documents", new[] { "LocationId" });
            DropIndex("dbo.DocumentFileAttachments", new[] { "DocumentId" });
            DropIndex("dbo.DocumentFileAttachments", new[] { "FileAttachmentId" });
            DropIndex("dbo.LocationFileAttachments", new[] { "LocationId" });
            DropIndex("dbo.LocationFileAttachments", new[] { "FileAttachmentId" });
            DropIndex("dbo.Staffs", new[] { "Location_LocationId" });
            DropIndex("dbo.Staffs", new[] { "PositionId" });
            DropIndex("dbo.Staffs", new[] { "DepartmentId" });
            DropIndex("dbo.Staffs", "StaffEmailIndex");
            DropIndex("dbo.Departments", new[] { "Location_LocationId1" });
            DropIndex("dbo.Locations", "LocationCodeIndex");
            DropIndex("dbo.Costs", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "PartnerHP_PartnerHPId" });
            DropIndex("dbo.Contracts", new[] { "ECMId" });
            DropIndex("dbo.Contracts", new[] { "LocationId" });
            DropIndex("dbo.Contracts", new[] { "PartnerId" });
            DropIndex("dbo.ContractFileAttachments", new[] { "ContractId" });
            DropIndex("dbo.ContractFileAttachments", new[] { "FileAttachmentId" });
            DropTable("dbo.Partners");
            DropTable("dbo.LocationHPFileAttachments");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.LocationHPs");
            DropTable("dbo.People");
            DropTable("dbo.PartnerHPs");
            DropTable("dbo.DocumentPartnerHPs");
            DropTable("dbo.DocumentHPs");
            DropTable("dbo.DocumentHPFileAttachments");
            DropTable("dbo.Documents");
            DropTable("dbo.DocumentFileAttachments");
            DropTable("dbo.FileAttachments");
            DropTable("dbo.LocationFileAttachments");
            DropTable("dbo.Positions");
            DropTable("dbo.Staffs");
            DropTable("dbo.Departments");
            DropTable("dbo.Locations");
            DropTable("dbo.ECMs");
            DropTable("dbo.Costs");
            DropTable("dbo.Contracts");
            DropTable("dbo.ContractFileAttachments");
        }
    }
}

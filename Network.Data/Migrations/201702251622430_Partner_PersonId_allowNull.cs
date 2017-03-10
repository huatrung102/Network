namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Partner_PersonId_allowNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Partners", new[] { "PersonId" });
            AlterColumn("dbo.Partners", "PersonId", c => c.Guid());
            CreateIndex("dbo.Partners", "PersonId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Partners", new[] { "PersonId" });
            AlterColumn("dbo.Partners", "PersonId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Partners", "PersonId");
        }
    }
}

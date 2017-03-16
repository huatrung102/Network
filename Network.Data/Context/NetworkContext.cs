using Network.Domain;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Network.Domain.Enum.EType;

namespace Network.Data.Context
{
    public class NetworkContext : DbContext, INetworkContext
    {
        public NetworkContext() : base("Name=NetworkDatabase") {
            ((IObjectContextAdapter)this).ObjectContext
              .ObjectMaterialized += (sender, args) =>
              {
                  var entity = args.Entity as IObjectWithState;
                  if (entity != null)
                  {
                      entity.State = State.Unchanged;
                  }
              };
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractFileAttachment> ContractFileAttachments { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentFileAttachment> DocumentFileAttachments { get; set; }
        public DbSet<DocumentHP> DocumentHPs { get; set; }
        public DbSet<DocumentHPFileAttachment> DocumentHPFileAttachments { get; set; }
        public DbSet<DocumentPartnerHP> DocumentPartnerHPs { get; set; }
        
        public DbSet<ECM> ECMs { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
     //   public DbSet<IntegrityPlan> IntegrityPlans { get; set; }
        //  public DbSet<IntegrityPlanFileAttachment> IntegrityPlanFileAttachments { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationFileAttachment> LocationFileAttachments { get; set; }
        public DbSet<LocationHP> LocationHPs { get; set; }
        public DbSet<LocationHPFileAttachment> LocationHPFileAttachments { get; set; }  

        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerHP> PartnerHP { get; set; }
        //phức tạp lúc làm nên bỏ ra để chung bảng với partner
       // public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Staff> Staff { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //disable delete on cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions
            //.Add(new AttributeToColumnAnnotationConvention<SqlDefaultDateTimeAttribute, string>
            //("SqlDefaultDateTime", (p, attributes) => attributes.Single().DefaultValue));
            //modelBuilder.Properties()
            //    .Where(x => x.PropertyType == typeof(DateTime) && x.Name.Equals("CreatedOn"))
            //    .Configure(c => c.HasColumnType("datetime2")
            //    .HasDatabaseGeneratedOption(Data‌​baseGeneratedOption.Computed)
            //    .HasColumnA‌​nnotation("SqlDefaultDateTime", "getdate()"));

            modelBuilder.Properties()
                .Where(x => x.PropertyType == typeof(string))
                .Configure(c => c.HasColumnType("NVARCHAR"));

        }

        public override int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }
        private void ApplyRules()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedOn") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedOn").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedOn").IsModified = false;
                }

                entry.Property("ModifiedOn").CurrentValue = DateTime.Now;
            }
        }
    }
}

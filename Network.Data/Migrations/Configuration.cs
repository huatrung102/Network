
namespace Network.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Data.Entity.Migrations.Model;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Network.Data.Context.NetworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
            
        }
        
        protected override void Seed(Network.Data.Context.NetworkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
    static internal class MigrationExtensions
    {
        public static void DeleteDefaultContraint(this IDbMigration migration, string tableName, string colName, bool suppressTransaction = false)
        {
            var sql = new SqlOperation(String.Format(@"DECLARE @SQL varchar(1000)
        SET @SQL='ALTER TABLE {0} DROP CONSTRAINT ['+(SELECT name
        FROM sys.default_constraints
        WHERE parent_object_id = object_id('{0}')
        AND col_name(parent_object_id, parent_column_id) = '{1}')+']';
        PRINT @SQL;
        EXEC(@SQL);", tableName, colName)) { SuppressTransaction = suppressTransaction };
            migration.AddOperation(sql);
        }
    }
}

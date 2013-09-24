using System.Data.Entity.Migrations;

namespace DataAccessFramework.Migrations
{
    /// <summary>
    /// This represents the configuration entity relating to the use of migrations for a given model.
    /// </summary>
    public class Configuration : DbMigrationsConfiguration<ApplicationDataContext>
    {
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the Configuration class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Database context instance to be used for updating seed data.</param>
        protected override void Seed(ApplicationDataContext context)
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
        #endregion
    }
}
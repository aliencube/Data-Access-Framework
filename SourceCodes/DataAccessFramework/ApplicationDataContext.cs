using DataAccessFramework.Entities;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace DataAccessFramework
{
    /// <summary>
    /// This represents the application data context entity.
    /// </summary>
    public partial class ApplicationDataContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the ApplicationDataContext object.
        /// </summary>
        public ApplicationDataContext()
            : base("ApplicationDatabase")
        {
        }

        /// <summary>
        /// Initialises a new instance of the ApplicationDataContext object.
        /// </summary>
        /// <param name="connectionString">SQL database connection string.</param>
        public ApplicationDataContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Initialises a new instance of the ApplicationDataContext object.
        /// </summary>
        /// <param name="connection">SQL database connection</param>
        public ApplicationDataContext(DbConnection connection)
            : base(connection, true)
        {
        }

        #endregion Constructors

        #region Properties

        //  Add the list of entities here...

        /// <summary>
        /// Gets or sets the list of users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the list of members.
        /// </summary>
        public DbSet<Member> Members { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// This method is called when the model for a derived context has been initialized,
        /// but before the model has been locked down and used to initialize the context.
        /// The default implementation of this method does nothing, but it can be overridden
        /// in a derived class such that the model can be further configured before it
        /// is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  Adds configurations automatically by scanning assembly.
            //  http://romiller.com/2012/03/26/dynamically-building-a-model-with-code-first

            //  Gets the MethodInfo instance for "Add".
            var addMethod = (typeof(ConfigurationRegistrar))
                .GetMethods()
                .Single(m => m.Name == "Add" && m.GetGenericArguments()
                                                 .Any(a => a.Name == "TEntityType"));

            //  Gets the list of assemblies that contain entity type configurations.
            var assemblies = AppDomain.CurrentDomain
                                      .GetAssemblies()
                                      .Where(p => p.GetName().Name.StartsWith("DataAccessFramework"))
                                      .OrderBy(p => p.GetName().Name)
                                      .ToList();

            //  Adds all types found.
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes()
                                             .Where(t => t.BaseType != null
                                                         && t.BaseType.IsGenericType
                                                         && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)))
                {
                    var entityType = type.BaseType.GetGenericArguments().Single();
                    var entityConfig = assembly.CreateInstance(type.FullName);

                    addMethod.MakeGenericMethod(entityType)
                             .Invoke(modelBuilder.Configurations, new object[] { entityConfig });
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion Methods
    }
}
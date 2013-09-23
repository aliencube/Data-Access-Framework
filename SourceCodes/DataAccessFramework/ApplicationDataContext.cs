using System.Data.Common;
using System.Data.Entity;

namespace DataAccessFramework
{
    /// <summary>
    /// This represents the application data context entity.
    /// </summary>
    public partial class ApplicationDataContext : DbContext
    {
        #region Constructors

        public ApplicationDataContext()
            : base("ApplicationDataContext")
        {
        }

        public ApplicationDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public ApplicationDataContext(DbConnection connection)
            : base(connection, true)
        {
        }

        #endregion Constructors

        #region Properties

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

        #endregion Methods
    }
}
using System.Data.Entity;

namespace DataAccessFramework
{
	/// <summary>
	/// This represents the application data context entity.
	/// </summary>
	public partial class ApplicationDataContext : DbContext
	{
		/// <summary>
		/// Gets or sets the list of users.
		/// </summary>
		public DbSet<User> Users { get; set; }

		/// <summary>
		/// Gets or sets the list of members.
		/// </summary>
		public DbSet<Member> Members { get; set; }
	}
}
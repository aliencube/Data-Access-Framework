using System;

namespace DataAccessFramework
{
	/// <summary>
	/// This represents a user entity of an account.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Gets or sets the user Id of the account, as a primary key.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the username of the account.
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the password of the account.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the email address of the account.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the date when the user is created.
		/// </summary>
		public DateTime DateCreated { get; set; }

		/// <summary>
		/// Gets or sets the userId which creates the user.
		/// </summary>
		public int CreatedBy { get; set; }
	}
}
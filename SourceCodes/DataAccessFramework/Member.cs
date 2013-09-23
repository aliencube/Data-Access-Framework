using System;

namespace DataAccessFramework
{
    /// <summary>
    /// This represents a member entity of an account.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or sets the member Id of the account, as a primary key.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the userId of the account, as a foreign key.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the given names of the account.
        /// </summary>
        public string GivenNames { get; set; }

        /// <summary>
        /// Gets or sets the surname of the account.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the date when the member is created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the userId which creates the member.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user instance.
        /// </summary>
        public virtual User User { get; set; }
    }
}
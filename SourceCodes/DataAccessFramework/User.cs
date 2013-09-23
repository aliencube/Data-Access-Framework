using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessFramework
{
    /// <summary>
    /// This represents a user entity of an account.
    /// </summary>
    public class User
    {
        public User()
        {
            this.Members = new List<Member>();
        }

        /// <summary>
        /// Gets or sets the user Id of the account, as a primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the account.
        /// </summary>
        [Required]
        [MaxLength(32, ErrorMessage = "Username must be shorter than or equal to 32 characters")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the account.
        /// </summary>
        [Required]
        [MinLength(8, ErrorMessage = "Password must be longer than or equal to 8 characters")]
        [MaxLength(64, ErrorMessage = "Password must be shorter than or equal to 64 characters")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email address of the account.
        /// </summary>
        [Required]
        [MaxLength(128, ErrorMessage = "Email must be shorter than or equal to 128 characters")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date when the user is created.
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the userId which creates the user.
        /// </summary>
        [Required]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets the list of member instances.
        /// </summary>
        public virtual ICollection<Member> Members { get; private set; }
    }
}
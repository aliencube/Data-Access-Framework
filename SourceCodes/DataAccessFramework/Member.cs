using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the userId of the account, as a foreign key.
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the given names of the account.
        /// </summary>
        [Required]
        [MaxLength(128, ErrorMessage = "Given names must be shorter than or equal to 128 characters")]
        public string GivenNames { get; set; }

        /// <summary>
        /// Gets or sets the surname of the account.
        /// </summary>
        [Required]
        [MaxLength(128, ErrorMessage = "Surname must be shorter than or equal to 128 characters")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the date when the member is created.
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the userId which creates the member.
        /// </summary>
        [Required]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user instance.
        /// </summary>
        [Required]
        public virtual User User { get; set; }
    }
}
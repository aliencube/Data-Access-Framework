using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessFramework
{
    /// <summary>
    /// This represents a member type configuration entity.
    /// </summary>
    public class MemberTypeConfiguration : EntityTypeConfiguration<Member>
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the MemberTypeConfiguration object.
        /// </summary>
        public MemberTypeConfiguration()
        {
            this.HasKey(p => p.MemberId);
            this.Property(p => p.MemberId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.GivenNames).IsRequired().HasMaxLength(128);
            this.Property(p => p.Surname).IsRequired().HasMaxLength(128);
            this.Property(p => p.DateCreated).IsRequired();
            this.Property(p => p.CreatedBy).IsRequired();

            this.HasRequired(p => p.User).WithMany(p => p.Members).HasForeignKey(p => p.UserId).WillCascadeOnDelete();
        }

        #endregion Constructors
    }
}
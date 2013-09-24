using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessFramework.Entities.TypeConfigurations
{
    /// <summary>
    /// This represents a user type configuration entity.
    /// </summary>
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the UserTypeConfiguration object.
        /// </summary>
        public UserTypeConfiguration()
        {
            this.HasKey(p => p.UserId);
            this.Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Username).IsRequired().HasMaxLength(32);
            this.Property(p => p.Password).IsRequired().HasMaxLength(64);
            this.Property(p => p.Email).IsRequired().HasMaxLength(128);
            this.Property(p => p.DateCreated).IsRequired();
            this.Property(p => p.CreatedBy).IsRequired();

            this.HasOptional(p => p.Member)
                .WithRequired(p => p.User)
                .Map(p => p.MapKey("UserId"));
        }

        #endregion Constructors
    }
}
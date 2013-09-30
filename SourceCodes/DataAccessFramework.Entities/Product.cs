using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessFramework.Entities
{
    /// <summary>
    /// This represents the product entity.
    /// </summary>
    [Table("ProductInfo")]
    public class Product
    {
        /// <summary>
        /// Gets or sets the product Id.
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [Required(ErrorMessage = "ProductName must be set")]
        [MaxLength(128, ErrorMessage = "ProductName is too long")]
        [MinLength(4, ErrorMessage = "ProductName is too short")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        [Column("Description", TypeName = "NTEXT")]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product alias.
        /// </summary>
        [NotMapped]
        public string ProductAlias { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        [Required(ErrorMessage = "UnitPrice must be set")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the date & time when the record is created.
        /// </summary>
        [Required(ErrorMessage = "DateCreated must be set")]
        public DateTime DateCreated { get; set; }
    }
}
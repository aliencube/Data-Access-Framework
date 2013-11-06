using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessFramework.Entities
{
    /// <summary>
    /// This represents the product order entity.
    /// </summary>
    public class ProductOrder
    {
        /// <summary>
        /// Gets or sets the product order Id.
        /// </summary>
        [Key]
        public int ProductOrderId { get; set; }

        /// <summary>
        /// Gets or sets the product Id.
        /// </summary>
        [Required(ErrorMessage = "ProductId must be set")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the order Id.
        /// </summary>
        [Required(ErrorMessage = "OrderId must be set")]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the order.
        /// </summary>
        [Required(ErrorMessage = "AmountOrdered must be set")]
        public int AmountOrdered { get; set; }
    }
}
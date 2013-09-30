using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessFramework.Entities
{
    /// <summary>
    /// This represents the order entity.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the order Id.
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the date & time when the order is placed.
        /// </summary>
        [Required(ErrorMessage = "DateOrdered must be set")]
        public DateTime DateOrdered { get; set; }

        /// <summary>
        /// Gets or sets the user Id that placed the order.
        /// </summary>
        [Required(ErrorMessage = "OrderBy must be set")]
        public int OrderBy { get; set; }
    }
}
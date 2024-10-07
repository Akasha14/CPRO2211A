using System.ComponentModel.DataAnnotations;

namespace Assignment1_App.Models
{
    public class QuoteModel
    {
        // User entered subtotal variable.
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal must be greater than zero.")]
        public decimal Subtotal { get; set; }

        // User entered discount percent variable.
        [Required]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100.")]
        public decimal DiscountPercent { get; set; }

        // Calculate amount to be taken off.
        public decimal DiscountAmount {
            get
               // Divide users desired percent by 100, then multiply by total entered.
            {
                return Subtotal * (DiscountPercent / 100);
            }
        }

        // Calculate final total.
        public decimal Total {
            get
            {
                return Subtotal - DiscountAmount;
            } 
        }

    }
}

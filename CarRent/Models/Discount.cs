using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Discount Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Discount amount must be greater than zero.")]
        [Display(Name = "Discount Amount")]
        public decimal DiscountAmount { get; set; }

        [Required(ErrorMessage = "Discount Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Discount Date")]
        public DateTime DiscountDate { get; set; }

        [Required(ErrorMessage = "Discount Code is required.")]
        [StringLength(50, ErrorMessage = "Discount code cannot exceed 50 characters.")]
        [Display(Name = "Discount Code")]
        public string DiscountCode { get; set; }

        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        [Display(Name = "Discount Percentage")]
        public double? DiscountPercentage { get; set; }
    }
}

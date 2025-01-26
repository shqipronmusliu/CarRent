using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public required string UserId { get; set; }

        [Required]
        public int CarId { get; set; }
        public  Car? Cars { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Status must be between 3 and 50 characters.")]
        public required string Status { get; set; }
    }
}

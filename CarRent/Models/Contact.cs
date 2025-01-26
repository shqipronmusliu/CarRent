using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters.")]
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Display(Name = "Email Address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Message is required.")]
        [Display(Name = "Message")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Message must be between 3 and 500 characters.")]
        public required string Message { get; set; }
        [Required(ErrorMessage = "SentAt is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "SentAt")]
        public DateTime SentAt { get; set; } 
    }

}

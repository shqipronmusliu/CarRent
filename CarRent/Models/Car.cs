using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters.")]
        [Display(Name="Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Model must be between 3 and 20 characters.")]
        [Display(Name = "Model")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters.")]
        public required string Description { get; set; }


        [Display(Name = "Image")]

        public string? ImagePath { get; set; }

        public string? UserId { get; set; }
        public bool IsReserved { get; set; }
        public  ICollection<Booking>? Bookings { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name="Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [Display(Name = "Model")]
        public required string Model { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public required string Price { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public required string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; } 

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;
    }
}

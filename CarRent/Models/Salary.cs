using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Salary
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Salary amount is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        // Navigation property for Employee
        public Employee? Employee { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Incident
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Incident Description is required.")]
        [StringLength(500, ErrorMessage = "Incident Description cannot exceed 500 characters.")]
        [Display(Name = "Incident Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Incident Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Incident Date")]
        public DateTime IncidentDate { get; set; }

        [Required(ErrorMessage = "Incident Severity is required.")]
        [Range(1, 5, ErrorMessage = "Severity must be between 1 and 5.")]
        [Display(Name = "Incident Severity")]
        public int Severity { get; set; } // Severity level (e.g., 1 = low, 5 = high)

        [Required(ErrorMessage = "Service related to the incident is required.")]
        [Display(Name = "Related Service")]
        public int ServiceId { get; set; } // Foreign key to the Service table

        // Navigation property for the related Service
        public Service Service { get; set; }

        [Required(ErrorMessage = "Incident Reported By is required.")]
        [StringLength(100, ErrorMessage = "Reporter Name cannot exceed 100 characters.")]
        [Display(Name = "Reported By")]
        public string ReportedBy { get; set; }

        [Display(Name = "Resolved By")]
        public string ResolvedBy { get; set; } // Optional, could be the name of the person who resolved the incident
    }
}


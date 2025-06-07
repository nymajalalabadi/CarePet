using System.ComponentModel.DataAnnotations;

namespace CarePet.Models
{
    public class VolunteerApplication
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select your availability")]
        public string Availability { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please describe your experience")]
        public string Experience { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please explain why you want to volunteer")]
        public string WhyVolunteer { get; set; } = string.Empty;

        public string Skills { get; set; } = string.Empty;

        public string EmergencyContactName { get; set; } = string.Empty;

        public string EmergencyContactPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must accept the Terms and Privacy Policy")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms and Privacy Policy")]
        public bool AcceptTerms { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
} 
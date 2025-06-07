using System.ComponentModel.DataAnnotations;

namespace CarePet.Models
{
    public class AdoptionApplication
    {
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "ZIP code is required")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "You must be at least 18 years old")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Occupation is required")]
        public string Occupation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Housing type is required")]
        public string HousingType { get; set; } = string.Empty; // Apartment, House, Condo

        public bool HasYard { get; set; } = false;

        public bool HasOtherPets { get; set; } = false;

        public string OtherPetsDetails { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please indicate if you have children")]
        public bool HasChildren { get; set; } = false;

        public string ChildrenAges { get; set; } = string.Empty;

        [Required(ErrorMessage = "Experience with pets is required")]
        public string PetExperience { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reason for adoption is required")]
        [MinLength(50, ErrorMessage = "Please provide a detailed reason (minimum 50 characters)")]
        public string AdoptionReason { get; set; } = string.Empty;

        public bool VeterinarianReference { get; set; } = false;

        public string VeterinarianName { get; set; } = string.Empty;

        public string VeterinarianPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact name is required")]
        public string EmergencyContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact phone is required")]
        [Phone(ErrorMessage = "Invalid emergency contact phone")]
        public string EmergencyContactPhone { get; set; } = string.Empty;

        public bool AgreeToTerms { get; set; } = false;

        public bool AgreeToHomeVisit { get; set; } = false;

        public int PetId { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
} 
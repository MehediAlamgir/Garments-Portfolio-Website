using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string InquiryDetails { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}

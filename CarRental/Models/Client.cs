using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Client : IValidatableObject
    {
        [DisplayName("Client ID")]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Address Line #3")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line #2")]
        public string AddressLine2 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Now.AddYears(-18) <= DateOfBirth)
            {
                yield return new ValidationResult("Should be 18+", new[] { "DateOfBirth" });
            }
        }
    }

    public enum Gender
    {
        Female,
        Male
    }
}

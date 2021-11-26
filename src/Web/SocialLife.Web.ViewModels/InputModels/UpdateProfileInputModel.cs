namespace SocialLife.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using SocialLife.Web.Infrastructure.Attributes;

    public class UpdateProfileInputModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Picture(ErrorMessage = "Invalid file extension.")]
        public IFormFile ProfilePicture { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string AboutDescription { get; set; }

        [RegularExpression(pattern: "[0-9]*", ErrorMessage = "Phone number should only contain digits (0-9).")]
        public string PhoneNumber { get; set; }

        [RegularExpression(pattern: "^[0-9]*$", ErrorMessage = "Postal code should only contain digits (0-9) and not exceed 5 digits.")]
        [MaxLength(5)]
        public string PostalCode { get; set; }
    }
}

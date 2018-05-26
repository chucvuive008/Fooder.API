using System;
using System.ComponentModel.DataAnnotations;

namespace Fooder.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "You Must specify a password between 6 and 12 character")]
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Street { get; set; }
        public string Apt { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip5 { get; set; }
        public string Favorite { get; set; }
    }
}
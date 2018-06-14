using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fooder.API.Models;

namespace Fooder.API.DTOs
{
    public class RestaurantForRegisterDto
    {
        [Required]
        public string Name { get; set; } 
        public string Website { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Suite { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip5 { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public RestaurantForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}
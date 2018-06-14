using System.Collections.Generic;
using Fooder.API.Models;

namespace Fooder.API.DTOs
{
    public class RestaurantForReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip5 { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
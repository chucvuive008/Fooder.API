namespace Fooder.API.Models
{
    public class Review
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string Detail { get; set; }
        public double Point { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
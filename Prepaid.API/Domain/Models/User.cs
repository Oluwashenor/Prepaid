namespace Prepaid.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public long ClientId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

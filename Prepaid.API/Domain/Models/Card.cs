namespace Prepaid.API.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public DateTime Expires { get; set; }
        public string CardType { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

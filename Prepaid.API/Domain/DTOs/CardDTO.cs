using Prepaid.API.Domain.Models;

namespace Prepaid.API.Domain.DTOs
{
    public class CardDTO
    {
        public string? CardNumber { get; set; }
        public DateTime Expires { get; set; }
        public string? Owner { get; set; }
        public string CardType { get; set; }
        public decimal Balance { get; set; }
    }

    public class CreateCardDTO
    {
        public string? CardNumber { get; set; }
        public string CardType { get; set; }
        public int UserId { get; set; }
    }


}

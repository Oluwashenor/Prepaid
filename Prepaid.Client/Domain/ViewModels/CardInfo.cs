namespace Prepaid.Client.Domain.ViewModels
{
    public class CardInfo
    {
        public string? CardNumber { get; set; }
        public DateTime Expires { get; set; }
        public string? Owner { get; set; }
        public string CardType { get; set; }
        public decimal Balance { get; set; }
    }
}

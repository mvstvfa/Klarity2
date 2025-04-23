namespace KlarityMVP.Models
{
    public class CheckoutViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal OrderTotal { get; set; }
    }
}
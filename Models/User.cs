using System.Collections.Generic;

namespace KlarityMVP.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name     { get; set; } = string.Empty;
        public string Email    { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role     { get; set; } = string.Empty;

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}

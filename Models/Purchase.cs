using System;
using System.Collections.Generic;

namespace KlarityMVP.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}

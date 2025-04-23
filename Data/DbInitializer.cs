using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KlarityMVP.Models;

namespace KlarityMVP.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Create the database if it doesn't exist
            context.Database.EnsureCreated();

            // If we've already seeded, do nothing
            if (context.Products.Any())
                return;

            // Seed products
            var products = new List<Product>
            {
                new Product { Name = "Klarity Original",       Type = "Clean energy, no crash",       Price = 2.99M },
                new Product { Name = "Klarity+ Berry Blast",   Type = "Boosted focus, berry flavor",   Price = 3.49M }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}

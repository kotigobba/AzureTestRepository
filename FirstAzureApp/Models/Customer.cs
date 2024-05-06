using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstAzureApp.Models
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
    }

    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
    }
}

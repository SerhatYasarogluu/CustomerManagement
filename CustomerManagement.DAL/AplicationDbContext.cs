using CustomerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<IndivialCustomer> IndivialCustomer { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomer { get; set; }
        public DbSet<Customer> Customers { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyDataBase;Trusted_Connection=True;TrustServerCertificate=True");

        }

    }
}

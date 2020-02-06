using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUDEX.Models
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}

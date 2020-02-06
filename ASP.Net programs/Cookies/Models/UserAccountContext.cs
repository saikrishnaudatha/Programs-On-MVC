using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOnCookies.Models
{
    public class UserAccountContext:DbContext
    {
        public UserAccountContext(DbContextOptions<UserAccountContext> options) : base(options)
        { }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}

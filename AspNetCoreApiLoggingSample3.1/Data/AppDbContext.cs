using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiLoggingSample.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApiLogItem> ApiLogs { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

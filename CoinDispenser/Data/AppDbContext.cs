using CoinDispenser.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CoinDispenser.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CoinLookup> CoinLookup { get; set; }

    }
}

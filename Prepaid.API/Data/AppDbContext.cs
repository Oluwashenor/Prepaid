using Microsoft.EntityFrameworkCore;
using Prepaid.API.Domain.Models;

namespace Prepaid.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}

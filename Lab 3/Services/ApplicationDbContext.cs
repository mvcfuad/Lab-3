using Lab_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_3.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}

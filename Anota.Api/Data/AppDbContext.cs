using Anota.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anota.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}

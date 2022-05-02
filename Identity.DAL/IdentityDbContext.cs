using Identity.DAL.Configuration;
using Identity.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.DAL;
public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}

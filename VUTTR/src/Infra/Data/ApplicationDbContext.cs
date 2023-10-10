using Microsoft.EntityFrameworkCore;
using VUTTR.Domain.Tools;

namespace VUTTR.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}
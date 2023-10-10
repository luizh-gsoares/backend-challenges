using Microsoft.EntityFrameworkCore;
using VUTTR.Domain.Tools;

namespace VUTTR.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ToolTag> ToolTags { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the many-to-many relationship between Tool and Tag
        modelBuilder.Entity<ToolTag>()
            .HasKey(tt => new { tt.ToolId, tt.TagId });

        modelBuilder.Entity<ToolTag>()
            .HasOne(tt => tt.Tool)
            .WithMany(t => t.ToolTags)
            .HasForeignKey(tt => tt.ToolId);

        modelBuilder.Entity<ToolTag>()
            .HasOne(tt => tt.Tag)
            .WithMany(t => t.ToolTags)
            .HasForeignKey(tt => tt.TagId);
    }
}
using FormazioneCRM.Application.Courses;
using FormazioneCRM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormazioneCRM.Infrastructure.Persistence;

public sealed class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Course>(entity =>
        {
            entity.ToTable("Courses");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Code).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Title).HasMaxLength(200).IsRequired();
            entity.HasIndex(x => x.Code).IsUnique();
        });
    }
}

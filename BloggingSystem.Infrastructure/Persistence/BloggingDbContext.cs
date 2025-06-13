using BloggingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloggingSystem.Infrastructure.Persistence;

public class BloggingDbContext : DbContext
{
    public BloggingDbContext(DbContextOptions<BloggingDbContext> options)
        : base(options) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Author entity
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(150);
            entity.HasMany(a => a.Blogs)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        });

        // Configure Blog entity
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(b => b.Url)
                .IsRequired()
                .HasMaxLength(200);
            entity.HasMany(b => b.Posts)
                .WithOne(p => p.Blog)
                .HasForeignKey(p => p.BlogId);
        });

        // Configure Post entity
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(p => p.Content)
                .IsRequired();
            entity.Property(p => p.DatePublished)
                .IsRequired();
        });

        // Seed data (optional, for testing purpose )
        // modelBuilder.Entity<Author>().HasData(
        //     new Author { Id = Guid.NewGuid(), Name = "AbuBakarr", Email = "abukamara1466@gmail.com" }
        // );
    }
}
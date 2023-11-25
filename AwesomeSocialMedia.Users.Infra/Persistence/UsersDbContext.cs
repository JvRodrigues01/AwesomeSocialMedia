using AwesomeSocialMedia.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSocialMedia.Users.Infra.Persistence
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.OwnsOne(u => u.Location,
                    builder =>
                    {
                        builder.Property(p => p.City)
                            .HasColumnName("City")
                            .IsRequired(false);

                        builder.Property(p => p.State)
                            .HasColumnName("State")
                            .IsRequired(false);

                        builder.Property(p => p.Country)
                            .HasColumnName("Country")
                            .IsRequired(false);
                    });

                e.OwnsOne(u => u.Contact,
                    builder =>
                    {
                        builder.Property(p => p.Email)
                            .HasColumnName("Email")
                            .IsRequired(false);

                        builder.Property(p => p.Website)
                            .HasColumnName("Website")
                            .IsRequired(false);

                        builder.Property(p => p.PhoneNumer)
                            .HasColumnName("PhoneNumer")
                            .IsRequired(false);
                    });

                e.Property(p => p.Header).IsRequired(false);
                e.Property(p => p.Description).IsRequired(false);

                e.Ignore(p => p.Events);
            });
        }
    }
}

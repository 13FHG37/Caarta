using Caarta.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Caarta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserSaveDeck>()
                .HasKey(s => new { s.AppUserId, s.DeckId });

            builder.Entity<UserSaveDeck>()
                .HasOne(s => s.AppUser)
                .WithMany(a => a.Saved)
                .HasForeignKey(s => s.AppUserId);

            builder.Entity<UserSaveDeck>()
                .HasOne(s => s.Deck)
                .WithMany(d => d.SavedBy)
                .HasForeignKey(s => s.DeckId);

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}

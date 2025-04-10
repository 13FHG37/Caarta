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
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserSaveDeck>()
                .HasOne(s => s.Deck)
                .WithMany(d => d.SavedBy)
                .HasForeignKey(s => s.DeckId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DeckInCardlist>()
                .HasKey(s => new { s.DeckId, s.CardlistId });

            builder.Entity<DeckInCardlist>()
                .HasOne(s => s.Cardlist)
                .WithMany(c => c.Decks)
                .HasForeignKey(s => s.CardlistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DeckInCardlist>()
                .HasOne(s => s.Deck)
                .WithMany(d => d.Cardlists)
                .HasForeignKey(s => s.DeckId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserSaveDeck> UserSaveDeck { get; set; }
        public DbSet<DeckInCardlist> DeckInCardlist { get; set; }
        public DbSet<Cardlist> Cardlists { get; set; }
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

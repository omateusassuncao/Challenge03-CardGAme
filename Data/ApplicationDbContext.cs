using Challenge03.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Challenge03.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Baralho> Baralhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id);

                entity.HasOne(c => c.Baralho)
                      .WithOne()
                      .HasForeignKey<Player>(c => c.BaralhoId)
                      .OnDelete(DeleteBehavior.SetNull); // Define a exclusão em cascata

            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id);

                entity.HasOne(c => c.Baralho)
                      .WithOne()
                      .HasForeignKey<Card>(c => c.BaralhoId)
                      .OnDelete(DeleteBehavior.SetNull); // Define a exclusão em cascata
            });

            modelBuilder.Entity<Baralho>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id);

                entity.HasOne(b => b.Player)
                      .WithOne(p => p.Baralho)
                      .HasForeignKey<Baralho>(b => b.PlayerId)
                      .OnDelete(DeleteBehavior.Cascade); // Define a exclusão em cascata

                entity.HasMany(b => b.Cards)
                      .WithOne(p => p.Baralho)
                      .OnDelete(DeleteBehavior.SetNull); // Define a exclusão em cascata
            });

            modelBuilder.Entity<Batalha>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id);

                entity.HasOne(b => b.Player_A)
                      .WithMany()
                      .OnDelete(DeleteBehavior.NoAction); // Define a exclusão em cascata como NO ACTION

                entity.HasOne(b => b.Player_B)
                      .WithMany()
                      .OnDelete(DeleteBehavior.NoAction); // Define a exclusão em cascata como NO ACTION

                entity.HasOne(b => b.Card_A)
                      .WithMany()
                      .OnDelete(DeleteBehavior.NoAction); // Define a exclusão em cascata como NO ACTION

                entity.HasOne(b => b.Card_B)
                      .WithMany()
                      .OnDelete(DeleteBehavior.NoAction); // Define a exclusão em cascata como NO ACTION
            });
        }


    }


}

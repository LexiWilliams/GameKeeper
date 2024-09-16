using GameKeeper.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace GameKeeper.Web.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<GameGenre> GameGenres { get; set; }

        public virtual DbSet<GameRecord> GameRecords { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<PlayerRecord> PlayerRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=ConnectionStrings:GameKeeper");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(e => new { e.GamesId, e.GenresId });

                entity.ToTable("GameGenre");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Games).WithMany(p => p.GameGenres).HasForeignKey(d => d.GamesId);

                entity.HasOne(d => d.Genres).WithMany(p => p.GameGenres).HasForeignKey(d => d.GenresId);
            });

            modelBuilder.Entity<GameRecord>(entity =>
            {
              //  entity.HasOne(d => d.Game).WithMany(p => p.GameRecords).HasForeignKey(d => d.GameId);
            });


            modelBuilder.Entity<PlayerRecord>(entity =>
            {
                entity.ToTable("PlayerRecord");

                entity.HasOne(d => d.GameRecord).WithMany(p => p.PlayerRecords).HasForeignKey(d => d.GameRecordId);

              //  entity.HasOne(d => d.Player).WithMany(p => p.PlayerRecords).HasForeignKey(d => d.PlayerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

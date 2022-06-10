using DreamTeam.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace DreamTeam.Data
{
    public class DreamTeamContext:DbContext
    {
        public DreamTeamContext() { }

        public DreamTeamContext(DbContextOptions options) : base(options) { }
        

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>(entity =>
            {
                entity
                    .HasOne(e => e.WorkTeam)
                    .WithMany(e => e.WorkTeams)
                    .OnDelete(DeleteBehavior.NoAction);
            });
           

            modelBuilder.Entity<Player>().HasOne(e => e.Team).WithOne(e => e.Player)
                .OnDelete(DeleteBehavior.NoAction).HasForeignKey("Team");
            
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=Team;Trusted_Connection=True;Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        
    }
    
}
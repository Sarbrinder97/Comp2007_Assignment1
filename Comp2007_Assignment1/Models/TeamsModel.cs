namespace Comp2007_Assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TeamsModel : DbContext
    {
        public TeamsModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<PLAYER> PLAYERS { get; set; }
        public virtual DbSet<TEAM> TEAMS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PLAYER>()
                .Property(e => e.PLAYER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PLAYER>()
                .Property(e => e.POINTS_PER_GAME)
                .HasPrecision(5, 2);

            modelBuilder.Entity<PLAYER>()
                .Property(e => e.REBOUNDS_PER_GAME)
                .HasPrecision(5, 2);

            modelBuilder.Entity<PLAYER>()
                .Property(e => e.ASSISTS_PER_GAME)
                .HasPrecision(5, 2);

            modelBuilder.Entity<TEAM>()
                .Property(e => e.TEAM_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TEAM>()
                .Property(e => e.TEAM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<TEAM>()
                .Property(e => e.TEAM_SPONSER)
                .IsUnicode(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Clube.Models.RPG
{
    public class RPGContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerLore> PlayerLores { get; set; }
        public DbSet<PlayerGoal> PlayerGoals { get; set; }
        public DbSet<PlayerBio> PlayerBios { get; set; }
        public DbSet<PlayerProfile> PlayerProfiles { get; set; }
        public DbSet<PlayerAttribute> PlayerAttributes { get; set; }

        public DbSet<RPGSystem> Systems { get; set; }
        public DbSet<RPGItem> Items { get; set; }
        public DbSet<PlayerInventory> PlayerInventories { get; set; }

        public DbSet<Note> Notes { get; set; }

        public string DbPath { get; }

        public RPGContext()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string dbFolderPath = Path.Combine( projectDirectory , "Databases" );
            DbPath = Path.Combine( dbFolderPath , "Clube.RPG.db" );
        }

        protected override void OnConfiguring( DbContextOptionsBuilder options )
            => options.UseSqlite( $"Data Source={DbPath}" );
    }
}

using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using static System.Environment;

namespace Clube.Models.RPG
{
    public class RPGContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerAttribute> Attributes { get; set; }
        public DbSet<Note> Notes { get; set; }

        public string DbPath { get; }

        public RPGContext()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string dbFolderPath = Path.Combine( projectDirectory , "Databases" );
            DbPath = Path.Combine( dbFolderPath , "Clube.RPG.db" );
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring( DbContextOptionsBuilder options )
            => options.UseSqlite( $"Data Source={DbPath}" );

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<PlayerAttribute>()
                .HasOne( p => p.Player )
                .WithMany( b => b.Attributes )
                .HasForeignKey( p => p.PlayerId )
            .HasPrincipalKey( b => b.Id );

            modelBuilder.Entity<Player>()
                .Property( b => b.Created )
                .HasDefaultValueSql( "getdate()" );

            modelBuilder.Entity<Note>()
                .Property( b => b.Created )
                .HasDefaultValueSql( "getdate()" );
        }
    }
}

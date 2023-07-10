using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {

        // entity sets 
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<FrequerntCompinaion> FrequerntCompinaions { get; set; }

        // Configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DoctorWhoCore;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Enemy>().HasData(
                new Enemy { EnemyId = 1, EnemyName = "Sawsan", Description = "Red Enemy" },
                new Enemy { EnemyId = 2, EnemyName = "Firas", Description = "Green Enemy" },
                new Enemy { EnemyId = 3, EnemyName = "Ahmad", Description = "Blue Enemy" },
                new Enemy { EnemyId = 4, EnemyName = "Ramy", Description = "Yellow enemy" },
                new Enemy { EnemyId = 5, EnemyName = "Rana", Description = "Pink Enemy" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Mohammad" },
                new Author { AuthorId = 2, AuthorName = "Huda" },
                new Author { AuthorId = 3, AuthorName = "Rula" },
                new Author { AuthorId = 4, AuthorName = "Lara" },
                new Author { AuthorId = 5, AuthorName = "Rami" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorNumber = 11, DoctorName = "Doctor1", BirthDate = new DateTime(1964, 2, 16), FirstEpisodeDate = new DateTime(2005, 3, 26), LastEpisodeDate = new DateTime(2005, 6, 18) },
                new Doctor { DoctorId = 2, DoctorNumber = 22, DoctorName = "Doctor2", BirthDate = new DateTime(1971, 4, 18), FirstEpisodeDate = new DateTime(2005, 6, 18), LastEpisodeDate = new DateTime(2010, 1, 1) },
                new Doctor { DoctorId = 3, DoctorNumber = 33, DoctorName = "Doctor3", BirthDate = new DateTime(1982, 10, 28), FirstEpisodeDate = new DateTime(2010, 4, 3), LastEpisodeDate = new DateTime(2013, 12, 25) },
                new Doctor { DoctorId = 4, DoctorNumber = 44, DoctorName = "Doctor4", BirthDate = new DateTime(1969, 4, 14), FirstEpisodeDate = new DateTime(2013, 12, 25), LastEpisodeDate = new DateTime(2017, 12, 25) },
                new Doctor { DoctorId = 5, DoctorNumber = 55, DoctorName = "Doctor5", BirthDate = new DateTime(1982, 6, 17), FirstEpisodeDate = new DateTime(2017, 12, 25), LastEpisodeDate = new DateTime(2012, 3, 3) }
            );

            modelBuilder.Entity<Companion>().HasData(
                new Companion { CompanionId = 1, CompanionName = "Companion1", WhoPlayed = "Ali" },
                new Companion { CompanionId = 2, CompanionName = "Companion2", WhoPlayed = "Kareem" },
                new Companion { CompanionId = 3, CompanionName = "Companion3", WhoPlayed = "Tim" },
                new Companion { CompanionId = 4, CompanionName = "Companion4", WhoPlayed = "Abdullah" },
                new Companion { CompanionId = 5, CompanionName = "Companion5", WhoPlayed = "Noor" }
            );

            modelBuilder.Entity<Episode>().HasData(
                new Episode { EpisodeId = 1, SeriesNumber = 1, EpisodeNumber = 1, EpisodeType = "Regular", Title = "Wedding", EpisodeDate = new DateTime(2005, 3, 26), AuthorId = 1, DoctorId = 1, Notes = "First episode in the first series" },
                new Episode { EpisodeId = 2, SeriesNumber = 2, EpisodeNumber = 4, EpisodeType = "NotRegular", Title = "Halloween", EpisodeDate = new DateTime(2006, 5, 6), AuthorId = 2, DoctorId = 2, Notes = null },
                new Episode { EpisodeId = 3, SeriesNumber = 3, EpisodeNumber = 11, EpisodeType = "Regular", Title = "The Eleventh Hour", EpisodeDate = new DateTime(2010, 4, 3), AuthorId = 2, DoctorId = 1, Notes = "Best Episode" },
                new Episode { EpisodeId = 4, SeriesNumber = 4, EpisodeNumber = 2, EpisodeType = "NotRegular", Title = "Listen", EpisodeDate = new DateTime(2014, 9, 13), AuthorId = 5, DoctorId = 1, Notes = null },
                new Episode { EpisodeId = 5, SeriesNumber = 5, EpisodeNumber = 1, EpisodeType = "Regular", Title = "The Woman Who Fell to Earth", EpisodeDate = new DateTime(2018, 10, 7), AuthorId = 3, DoctorId = 4, Notes = "First episode in the fifth series" },
                new Episode { EpisodeId = 6, SeriesNumber = 7, EpisodeNumber = 12, EpisodeType = "NotRegular", Title = "TestNullDoctor", EpisodeDate = new DateTime(2015, 3, 26), AuthorId = 1, DoctorId = null, Notes = null }
            );

        }

    }
}

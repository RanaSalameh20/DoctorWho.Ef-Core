using Dapper;
using DoctorWho.Db.ViewsModels;
using Microsoft.Data.SqlClient;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        private readonly AuthorRepository _authorRepository;
        private readonly DoctorRepository _doctorRepository;
        private readonly string _connectionString;

        public EpisodeRepository(DoctorWhoCoreDbContext context,
            AuthorRepository authorRepository,DoctorRepository doctorRepository
            ) {
            _context = context;
            _authorRepository = authorRepository;
            _doctorRepository = doctorRepository;
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DoctorWhoCore;Trusted_Connection=True;"

        }
        void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int authorId, int? doctorId)
        {
            var author = _authorRepository.GetAuthorById(authorId);
            if (author != null)
            {
                var episode = new Episode
                {
                    SeriesNumber = seriesNumber,
                    EpisodeNumber = episodeNumber,
                    EpisodeType = episodeType,
                    Title = title,
                    EpisodeDate = episodeDate,
                    Author = author
                };

                var doctor = _doctorRepository.GetDoctorById(doctorId);

                if (doctor != null)
                {
                    episode.Doctor = doctor;
                }

                _context.Episodes.Add(episode);
                _context.SaveChanges();
            }

        }
        void UpdateEpisode(int episodeId, string newEpisodeTitle, DateTime newEpisodeDate, int newAuthorId)
        {
            var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);
            var author = _context.Authors.FirstOrDefault(a => a.AuthorId == newAuthorId);

            if (episode != null)
            {
                episode.Title = newEpisodeTitle;
                episode.EpisodeDate = newEpisodeDate;
            }
            if (author != null)
            {
                episode.Author = author;
            }


            _context.SaveChanges();
            Console.WriteLine("done");
        }
        void DeleteEpisode(int episodeId)
        {
            var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);

            if (episode != null)
            {
                _context.Episodes.Remove(episode);
            }

            _context.SaveChanges();
        }
        void AddEnemyToEpisode()
        {
            var enemy1 = _context.Enemies.Find(1);
            var enemy2 = _context.Enemies.Find(2);
            var episode = _context.Episodes.Find(2);

            episode.Enemies.Add(enemy1);
            episode.Enemies.Add(enemy2);

            _context.SaveChanges();
        }
        void addCompanionToEpisode()
        {
            var companion1 = _context.Companions.Find(4);
            var companion2 = _context.Companions.Find(5);
            var companion3 = _context.Companions.Find(6);
            var episode1 = _context.Episodes.Find(4);
            var episode2 = _context.Episodes.Find(5);

            episode1.Companions.Add(companion1);
            episode1.Companions.Add(companion2);
            episode1.Companions.Add(companion3);
            episode2.Companions.Add(companion1);

            _context.SaveChanges();
        }
        void EpisodesView()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var episodes = connection.Query<EpisodeView>("SELECT * FROM ViewEpisodes");

                foreach (var episode in episodes)
                {
                    Console.WriteLine($"Episode ID: {episode.EpisodeId}");
                    Console.WriteLine($"Series Number: {episode.SeriesNumber}");
                    Console.WriteLine($"Episode Number: {episode.EpisodeNumber}");
                    Console.WriteLine($"Episode Type: {episode.EpisodeType}");
                    Console.WriteLine($"Title: {episode.Title}");
                    Console.WriteLine($"Episode Date: {episode.EpisodeDate}");
                    Console.WriteLine($"Author ID: {episode.AuthorId}");
                    Console.WriteLine($"Doctor ID: {episode.DoctorId}");
                    Console.WriteLine($"Author: {episode.Author}");
                    Console.WriteLine($"Doctor: {episode.Doctor}");
                    Console.WriteLine($"Companions: {episode.Companions}");
                    Console.WriteLine($"Enemies: {episode.Enemies}");

                }

            }
        }
    }
}

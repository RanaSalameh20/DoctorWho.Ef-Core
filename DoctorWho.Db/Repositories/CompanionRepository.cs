using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DoctorWho.Db.Repositories
{
    public class CompanionRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        private readonly string _connectionString;

        public CompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
             _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DoctorWhoCore;Trusted_Connection=True;";

        }

        void CreateCompanion(string companionName, string whoPlayed)
        {
            var companion = new Companion
            {
                CompanionName = companionName,
                WhoPlayed = whoPlayed
            };

            _context.Companions.Add(companion);
            _context.SaveChanges();
        }
        void UpdateCompanion(int companionId, string newCompanionName)
        {
            var companion = _context.Companions.FirstOrDefault(c => c.CompanionId == companionId);

            if (companion != null)
            {
                companion.CompanionName = newCompanionName;

            }
            _context.SaveChanges();
            Console.WriteLine("Companion updated successfully.");

        }
        void DeleteCompanion(int companionId)
        {
            var companion = _context.Companions

                .FirstOrDefault(c => c.CompanionId == companionId);

            if (companion != null)
            {
                _context.Companions.Remove(companion);
            }

            _context.SaveChanges();
        }
        void GetCompanion(int companionId)
        {
            var companion = _context.Companions
                .Include(c => c.Episodes)
                .FirstOrDefault(c => c.CompanionId == companionId);
            var companionEpisodes = companion.Episodes.ToList();
            if (companion != null)
            {
                Console.WriteLine(companion.CompanionName);
                Console.WriteLine(companion.WhoPlayed);
                companionEpisodes.ForEach(c => Console.WriteLine(c.Title));
            }

        }
        void GetCompanionsList(int episodeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@EpisodeId", episodeId);

                var result = connection.QueryFirstOrDefault<string>
                    ("SELECT dbo.GetCompanions(@EpisodeId)",
                    parameters, commandType: CommandType.Text);
                Console.WriteLine(result);
            }
        }
        void GetMostFrequentCompanions()
        {
            var companionsWithFrequency = _context.FrequerntCompinaions
                .FromSqlRaw("EXEC spMostFrequentlyCompanion")
                .ToList();

            string result = string.Join(", ", companionsWithFrequency.Select(c => $"{c.CompanionName}: {c.Frequency}"));
            Console.WriteLine(result);

        }

    }
}

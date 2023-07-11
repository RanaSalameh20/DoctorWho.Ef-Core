using Dapper;
using DoctorWho.Db.ProceduresModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DoctorWho.Db.Repositories
{
    public class EnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        private string _connectionString;

        public EnemyRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DoctorWhoCore;Trusted_Connection=True;"
        }
        void CreateEnemy(string enemyName, string description)
        {
            var enemy = new Enemy
            {
                EnemyName = enemyName,
                Description = description,
            };

            _context.Enemies.Add(enemy);
            _context.SaveChanges();

            Console.WriteLine("Enemy created successfully.");
        }
        void UpdateEnemy(int enemyId, string newEnemyName, string newDescription)
        {
            var enemy = _context.Enemies.FirstOrDefault(e => e.EnemyId == enemyId);

            if (enemy != null)
            {
                enemy.EnemyName = newEnemyName;
                enemy.Description = newDescription;
            }

            _context.SaveChanges();
        }
        void DeleteEnemy(int enemyId)
        {
            var enemy = _context.Enemies
                .Include(e => e.Episodes)
                .FirstOrDefault(e => e.EnemyId == enemyId);

            if (enemy != null)
            {
                _context.Enemies.Remove(enemy);
            }

            _context.SaveChanges();
        }
        void GetEnemy(int enemyId)
        {
            var enemy = _context.Enemies
                .Include(e => e.Episodes)
                .FirstOrDefault(e => e.EnemyId == enemyId);
            if (enemy != null)
            {
                Console.WriteLine("EnemyId: " + enemy.EnemyId);
                Console.WriteLine("EnemyName: " + enemy.EnemyName);
                Console.WriteLine("Description: " + enemy.Description);
                Console.WriteLine("Episodes: " + enemy.Episodes.Count);
            }

        }
        void GetEnemiesList(int episodeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@EpisodeId", episodeId);

                var result = connection.QueryFirstOrDefault<string>
                    ("SELECT dbo.GetEnemies(@EpisodeId)",
                    parameters, commandType: CommandType.Text);
                Console.WriteLine(result);
            }
        }
        void GetMostFrequentEnemies()
        {

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var enemies = connection.Query<FrequentEnemy>("spMostFrequentlyEnemies"
                    , commandType: CommandType.StoredProcedure).ToList();

                string result = string.Join(", ", enemies.Select(e => $"{e.EnemyName}: {e.EnemyAppearances}"));
                Console.WriteLine(result);

            }
        }


    }
}

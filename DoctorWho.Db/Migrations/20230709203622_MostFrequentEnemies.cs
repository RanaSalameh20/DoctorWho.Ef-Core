using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class MostFrequentEnemies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
              @"CREATE PROCEDURE spMostFrequentlyEnemies
              AS
              BEGIN
              SELECT TOP 3 e.EnemyName, COUNT(ee.EnemiesEnemyId) AS EnemyAppearances
              FROM Enemies e
              JOIN EnemyEpisode ee ON e.EnemyId = ee.EnemiesEnemyId
              GROUP BY e.EnemyName
              ORDER BY COUNT(ee.EnemiesEnemyId) DESC;
              END;");
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
             @"DROP PROCEDURE spMostFrequentlyEnemies");
        }
    }
}

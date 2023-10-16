using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class MostFrequentCompanion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"CREATE PROCEDURE spMostFrequentlyCompanion
            AS
            BEGIN
            
            SELECT TOP 3  c.CompanionName, COUNT(ec.CompanionsCompanionId) AS CompanionAppearances 
            FROM  Companions c
            JOIN  CompanionEpisode ec ON c.CompanionId = ec.CompanionsCompanionId
            GROUP BY c.CompanionId
            ORDER BY COUNT(ec.CompanionsCompanionId) DESC;
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
         @"DROP PROCEDURE spMostFrequentlyCompanion");
        }
    }
}

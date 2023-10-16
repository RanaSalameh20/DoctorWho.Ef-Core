using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddEpisodesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW ViewEpisodes AS
                SELECT e.*,
                a.AuthorName AS Author, d.DoctorName AS Doctor,
                dbo.GetCompanions(e.EpisodeId) AS Companions,
                dbo.GetEnemies(e.EpisodeId) AS Enemies

                FROM Episodes e
                LEFT JOIN Authors a ON e.AuthorId = a.AuthorId
                LEFT JOIN Doctors d ON e.DoctorId = d.DoctorId;
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP VIEW ViewEpisodes");
        }
    }
}

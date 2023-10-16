using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddGetCompanionsFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION GetCompanions(@EpisodeId INT)
                RETURNS VARCHAR(255)
                AS
                BEGIN


                DECLARE @CompanionList VARCHAR(255) = '';

                SELECT @CompanionList = @CompanionList + c.CompanionName + ', '
                FROM Companions c
                JOIN CompanionEpisode ce ON c.CompanionId = ce.CompanionsCompanionId
                WHERE ce.EpisodesEpisodeId = @EpisodeId;

                RETURN @CompanionList;
                END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"DROP FUNCTION GetCompanions");
        }
    }
}

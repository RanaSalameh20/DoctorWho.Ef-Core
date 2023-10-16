using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Mohammad" },
                    { 2, "Huda" },
                    { 3, "Rula" },
                    { 4, "Lara" },
                    { 5, "Rami" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Companion1", "Ali" },
                    { 2, "Companion2", "Kareem" },
                    { 3, "Companion3", "Tim" },
                    { 4, "Companion4", "Abdullah" },
                    { 5, "Companion5", "Noor" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1964, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor1", 11, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1971, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor2", 22, new DateTime(2005, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1982, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor3", 33, new DateTime(2010, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1969, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor4", 44, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1982, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor5", 55, new DateTime(2017, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Red Enemy", "Sawsan" },
                    { 2, "Green Enemy", "Firas" },
                    { 3, "Blue Enemy", "Ahmad" },
                    { 4, "Yellow enemy", "Ramy" },
                    { 5, "Pink Enemy", "Rana" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Regular", "First episode in the first series", 1, "Wedding" },
                    { 2, 2, 2, new DateTime(2006, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "NotRegular", null, 2, "Halloween" },
                    { 3, 2, 1, new DateTime(2010, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Regular", "Best Episode", 3, "The Eleventh Hour" },
                    { 4, 5, 1, new DateTime(2014, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "NotRegular", null, 4, "Listen" },
                    { 5, 3, 4, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Regular", "First episode in the fifth series", 5, "The Woman Who Fell to Earth" },
                    { 6, 1, null, new DateTime(2015, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "NotRegular", null, 7, "TestNullDoctor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

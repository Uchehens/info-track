using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoTrack.Infrastructure.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Query = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Accept = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequestPayload = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Cookie = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Identity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trends", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SearchEngines",
                columns: new[] { "Id", "Accept", "Cookie", "Domain", "Identifier", "IsActive", "Method", "Query", "RequestPayload" },
                values: new object[] { 1, "text/plain", "1P_JAR=2021-08-25-19; CONSENT=YES+srp.gws-20210816-0-RC3.en+FX+146; NID=222=AmjNKzCPWZjOOlug3HXE063uyLK02Twke1WC05QsXNsr6CAFLNvKL9xuUtkHniPmKPG-HfhrVSYYID4GiQ1WQxu5gUahwchMX9DWAR7TvyNE2YgowxoLZeGMnSnq3tTjfmUCVGmd9QMes__5rpjG6bDDmo6YiEE6so4phO2Vyrc", "google.uk.co", "google", true, "GET", "https://www.google.co.uk/search?num=100&q={0}", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchEngines");

            migrationBuilder.DropTable(
                name: "Trends");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Interdisciplinary.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    AvailableTickets = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_Shows_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Hilmer123!", "Christian" },
                    { 2, "123", "Ingrida" },
                    { 3, "skov", "Karsten" },
                    { 4, "t", "t" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, "Opera" },
                    { 2, "Concert" },
                    { 3, "Play" },
                    { 4, "Ballet" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AdminId", "AvailableTickets", "Date", "GenreId", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, 1, 230, new DateTime(2021, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://i.ibb.co/zPGkR3q/la-traviata.png", 189, "La traviata" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AdminId", "AvailableTickets", "Date", "GenreId", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, 2, 451, new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://i.ibb.co/KhKHJv9/the-four-seasons.png", 169, "The four seasons" });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_AdminId",
                table: "Shows",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_GenreId",
                table: "Shows",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week_3_Inno_PreTrainee.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1799, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Александр Пушкин" },
                    { 2, new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фёдор Достоевский" },
                    { 3, new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лев Толстой" },
                    { 4, new DateTime(1860, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон Чехов" },
                    { 5, new DateTime(1809, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Николай Гоголь" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1833, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Евгений Онегин" },
                    { 2, 2, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Преступление и наказание" },
                    { 3, 3, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Война и мир" },
                    { 4, 4, new DateTime(1904, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вишнёвый сад" },
                    { 5, 5, new DateTime(1842, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мёртвые души" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSEM3.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactName",
                table: "Contacts",
                column: "ContactName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}

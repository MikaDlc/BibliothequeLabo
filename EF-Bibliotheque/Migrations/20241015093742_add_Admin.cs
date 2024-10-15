using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class add_Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salage",
                table: "Client");

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "Client",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Salage",
                table: "Client",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leases_LeaseDate",
                table: "Leases");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_LeaseID",
                table: "Leases",
                column: "LeaseID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leases_LeaseID",
                table: "Leases");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_LeaseDate",
                table: "Leases",
                column: "LeaseDate",
                unique: true);
        }
    }
}

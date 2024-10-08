using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class Update_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLeases_Client_ClientID",
                table: "BookLeases");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSales_Client_ClientID",
                table: "BookSales");

            migrationBuilder.DropIndex(
                name: "IX_BookSales_ClientID",
                table: "BookSales");

            migrationBuilder.DropIndex(
                name: "IX_BookLeases_ClientID",
                table: "BookLeases");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "BookSales");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "BookLeases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "BookSales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "BookLeases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookSales_ClientID",
                table: "BookSales",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLeases_ClientID",
                table: "BookLeases",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLeases_Client_ClientID",
                table: "BookLeases",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSales_Client_ClientID",
                table: "BookSales",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID");
        }
    }
}

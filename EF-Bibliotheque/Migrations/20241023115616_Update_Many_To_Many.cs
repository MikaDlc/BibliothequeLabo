using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class Update_Many_To_Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "BookLeases");

            migrationBuilder.DropTable(
                name: "BookSales");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthorID = table.Column<int>(type: "int", nullable: false),
                    BooksBookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorID, x.BooksBookID });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsAuthorID",
                        column: x => x.AuthorsAuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    GenresGName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksBookID, x.GenresGName });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresGName",
                        column: x => x.GenresGName,
                        principalTable: "Genres",
                        principalColumn: "GName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLease",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    LeasesLeaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLease", x => new { x.BooksBookID, x.LeasesLeaseID });
                    table.ForeignKey(
                        name: "FK_BookLease_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLease_Leases_LeasesLeaseID",
                        column: x => x.LeasesLeaseID,
                        principalTable: "Leases",
                        principalColumn: "LeaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSale",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    SalesSaleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSale", x => new { x.BooksBookID, x.SalesSaleID });
                    table.ForeignKey(
                        name: "FK_BookSale_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSale_Sales_SalesSaleID",
                        column: x => x.SalesSaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookID",
                table: "AuthorBook",
                column: "BooksBookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresGName",
                table: "BookGenre",
                column: "GenresGName");

            migrationBuilder.CreateIndex(
                name: "IX_BookLease_LeasesLeaseID",
                table: "BookLease",
                column: "LeasesLeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_BookSale_SalesSaleID",
                table: "BookSale",
                column: "SalesSaleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "BookLease");

            migrationBuilder.DropTable(
                name: "BookSale");

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookID, x.AuthorID });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    GName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BookID, x.GName });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres_GName",
                        column: x => x.GName,
                        principalTable: "Genres",
                        principalColumn: "GName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLeases",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    LeaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLeases", x => new { x.BookID, x.LeaseID });
                    table.ForeignKey(
                        name: "FK_BookLeases_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLeases_Leases_LeaseID",
                        column: x => x.LeaseID,
                        principalTable: "Leases",
                        principalColumn: "LeaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSales",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    SaleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSales", x => new { x.BookID, x.SaleID });
                    table.ForeignKey(
                        name: "FK_BookSales_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSales_Sales_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorID",
                table: "BookAuthors",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GName",
                table: "BookGenres",
                column: "GName");

            migrationBuilder.CreateIndex(
                name: "IX_BookLeases_LeaseID",
                table: "BookLeases",
                column: "LeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_BookSales_SaleID",
                table: "BookSales",
                column: "SaleID");
        }
    }
}

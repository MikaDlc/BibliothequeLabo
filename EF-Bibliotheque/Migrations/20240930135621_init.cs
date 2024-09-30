using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GName);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    LibraryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.LibraryID);
                });

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
                name: "Authentifications",
                columns: table => new
                {
                    AuthentificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Passwd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentifications", x => x.AuthentificationID);
                    table.ForeignKey(
                        name: "FK_Client_Authentification",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    LeaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.LeaseID);
                    table.ForeignKey(
                        name: "FK_Lease_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sale_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
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
                name: "BookLibrary",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    LibraryID = table.Column<int>(type: "int", nullable: false),
                    QDispo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLibrary", x => new { x.BookID, x.LibraryID });
                    table.ForeignKey(
                        name: "FK_BookLibrary_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLibrary_Library_LibraryID",
                        column: x => x.LibraryID,
                        principalTable: "Library",
                        principalColumn: "LibraryID",
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
                name: "IX_Authentifications_AuthentificationID",
                table: "Authentifications",
                column: "AuthentificationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authentifications_ClientID",
                table: "Authentifications",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authentifications_Email",
                table: "Authentifications",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorID",
                table: "Authors",
                column: "AuthorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name_FirstName",
                table: "Authors",
                columns: new[] { "Name", "FirstName" },
                unique: true);

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
                name: "IX_BookLibrary_BookID_LibraryID",
                table: "BookLibrary",
                columns: new[] { "BookID", "LibraryID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookLibrary_LibraryID",
                table: "BookLibrary",
                column: "LibraryID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookID",
                table: "Books",
                column: "BookID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title_Edition",
                table: "Books",
                columns: new[] { "Title", "Edition" });

            migrationBuilder.CreateIndex(
                name: "IX_BookSales_SaleID",
                table: "BookSales",
                column: "SaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GName",
                table: "Genres",
                column: "GName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leases_ClientID",
                table: "Leases",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_LeaseDate",
                table: "Leases",
                column: "LeaseDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Library_LibraryID",
                table: "Library",
                column: "LibraryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientID",
                table: "Sales",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SaleID",
                table: "Sales",
                column: "SaleID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentifications");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "BookLeases");

            migrationBuilder.DropTable(
                name: "BookLibrary");

            migrationBuilder.DropTable(
                name: "BookSales");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}

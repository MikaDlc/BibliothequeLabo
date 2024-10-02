﻿// <auto-generated />
using System;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Bibliotheque.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Bibliotheque.Entities.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AuthorID");

                    b.HasIndex("AuthorID")
                        .IsUnique();

                    b.HasIndex("Name", "FirstName")
                        .IsUnique();

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EditionDate")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BookID");

                    b.HasIndex("BookID")
                        .IsUnique();

                    b.HasIndex("Title", "Edition");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "AuthorID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookAuthors", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookGenre", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<string>("GName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookID", "GName");

                    b.HasIndex("GName");

                    b.ToTable("BookGenres", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookLease", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("LeaseID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "LeaseID");

                    b.HasIndex("LeaseID");

                    b.ToTable("BookLeases", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookLibrary", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("LibraryID")
                        .HasColumnType("int");

                    b.Property<int>("QDispo")
                        .HasColumnType("int");

                    b.HasKey("BookID", "LibraryID");

                    b.HasIndex("LibraryID");

                    b.HasIndex("BookID", "LibraryID")
                        .IsUnique();

                    b.ToTable("BookLibrary", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookSale", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("SaleID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "SaleID");

                    b.HasIndex("SaleID");

                    b.ToTable("BookSales", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumberH")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Passwd")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Salage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClientID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Genre", b =>
                {
                    b.Property<string>("GName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GName");

                    b.HasIndex("GName")
                        .IsUnique();

                    b.ToTable("Genres", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Lease", b =>
                {
                    b.Property<int>("LeaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaseID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LeaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeaseID");

                    b.HasIndex("ClientID");

                    b.HasIndex("LeaseID")
                        .IsUnique();

                    b.ToTable("Leases", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Library", b =>
                {
                    b.Property<int>("LibraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibraryID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumberH")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LibraryID");

                    b.HasIndex("LibraryID")
                        .IsUnique();

                    b.ToTable("Library", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Sale", b =>
                {
                    b.Property<int>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("SaleID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SaleID")
                        .IsUnique();

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookAuthor", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Bibliotheque.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookGenre", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Bibliotheque.Entities.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookLease", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Book", "Book")
                        .WithMany("BookLeases")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Bibliotheque.Entities.Lease", "Lease")
                        .WithMany("BookLeases")
                        .HasForeignKey("LeaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Lease");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookLibrary", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Book", "Book")
                        .WithMany("BookLibraries")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Bibliotheque.Entities.Library", "Library")
                        .WithMany("BookLibraries")
                        .HasForeignKey("LibraryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.BookSale", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Book", "Book")
                        .WithMany("BookSales")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Bibliotheque.Entities.Sale", "Sale")
                        .WithMany("BookSales")
                        .HasForeignKey("SaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Lease", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Client", "Client")
                        .WithMany("Leases")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Lease_Client");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Sale", b =>
                {
                    b.HasOne("EF_Bibliotheque.Entities.Client", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Sale_Client");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookGenres");

                    b.Navigation("BookLeases");

                    b.Navigation("BookLibraries");

                    b.Navigation("BookSales");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Client", b =>
                {
                    b.Navigation("Leases");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Lease", b =>
                {
                    b.Navigation("BookLeases");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Library", b =>
                {
                    b.Navigation("BookLibraries");
                });

            modelBuilder.Entity("EF_Bibliotheque.Entities.Sale", b =>
                {
                    b.Navigation("BookSales");
                });
#pragma warning restore 612, 618
        }
    }
}

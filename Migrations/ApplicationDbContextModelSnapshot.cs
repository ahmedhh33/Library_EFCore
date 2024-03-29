﻿// <auto-generated />
using System;
using Library_EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_EFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_EFCore.NewFolder.BookManagement", b =>
                {
                    b.Property<int>("B_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("B_ID"));

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("publication_year")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("B_ID");

                    b.ToTable("bookManagements");
                });

            modelBuilder.Entity("Library_EFCore.NewFolder.BorrowingTransactions", b =>
                {
                    b.Property<int>("TraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TraID"));

                    b.Property<int>("B_ID")
                        .HasColumnType("int");

                    b.Property<int>("Pat_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("borrowing_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("return_date")
                        .HasColumnType("datetime2");

                    b.HasKey("TraID");

                    b.HasIndex("B_ID");

                    b.HasIndex("Pat_ID");

                    b.ToTable("BorrowingTransactions");
                });

            modelBuilder.Entity("Library_EFCore.NewFolder.PatronManagement", b =>
                {
                    b.Property<int>("Pat_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pat_ID"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pat_ID");

                    b.ToTable("patronManagements");
                });

            modelBuilder.Entity("Library_EFCore.NewFolder.BorrowingTransactions", b =>
                {
                    b.HasOne("Library_EFCore.NewFolder.BookManagement", "BookManagement")
                        .WithMany("borrowingTransactions")
                        .HasForeignKey("B_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_EFCore.NewFolder.PatronManagement", "PatronManagement")
                        .WithMany("borrowingTransactions")
                        .HasForeignKey("Pat_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookManagement");

                    b.Navigation("PatronManagement");
                });

            modelBuilder.Entity("Library_EFCore.NewFolder.BookManagement", b =>
                {
                    b.Navigation("borrowingTransactions");
                });

            modelBuilder.Entity("Library_EFCore.NewFolder.PatronManagement", b =>
                {
                    b.Navigation("borrowingTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}

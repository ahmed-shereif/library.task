﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using librar.data.Data;

#nullable disable

namespace librar.data.Migrations
{
    [DbContext(typeof(libraryDbContext))]
    partial class libraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("librar.data.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Auther")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Auther = "F. Scott Fitzgerald",
                            CategoryId = 1,
                            Description = "A novel by F. Scott Fitzgerald",
                            Name = "The Great Gatsby",
                            Price = 10.99f,
                            Stock = 100
                        },
                        new
                        {
                            BookId = 2,
                            Auther = "Stephen Hawking",
                            CategoryId = 2,
                            Description = "A book by Stephen Hawking",
                            Name = "A Brief History of Time",
                            Price = 15.5f,
                            Stock = 50
                        },
                        new
                        {
                            BookId = 3,
                            Auther = "Yuval Noah Harari",
                            CategoryId = 3,
                            Description = "A brief history of humankind",
                            Name = "Sapiens",
                            Price = 20f,
                            Stock = 75
                        });
                });

            modelBuilder.Entity("librar.data.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Fictional Books",
                            Name = "Fiction"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Scientific Books",
                            Name = "Science"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Historical Books",
                            Name = "History"
                        });
                });

            modelBuilder.Entity("librar.data.Entities.Book", b =>
                {
                    b.HasOne("librar.data.Entities.Category", "Category")
                        .WithMany("Book")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("librar.data.Entities.Category", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}

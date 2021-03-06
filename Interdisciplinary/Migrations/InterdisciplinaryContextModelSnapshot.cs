﻿// <auto-generated />
using System;
using Interdisciplinary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Interdisciplinary.Migrations
{
    [DbContext(typeof(InterdisciplinaryContext))]
    partial class InterdisciplinaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Interdisciplinary.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            Password = "Hilmer123!",
                            Username = "Christian"
                        },
                        new
                        {
                            AdminId = 2,
                            Password = "123",
                            Username = "Ingrida"
                        },
                        new
                        {
                            AdminId = 3,
                            Password = "skov",
                            Username = "Karsten"
                        },
                        new
                        {
                            AdminId = 4,
                            Password = "t",
                            Username = "t"
                        });
                });

            modelBuilder.Entity("Interdisciplinary.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Title = "Opera"
                        },
                        new
                        {
                            GenreId = 2,
                            Title = "Concert"
                        },
                        new
                        {
                            GenreId = 3,
                            Title = "Play"
                        },
                        new
                        {
                            GenreId = 4,
                            Title = "Ballet"
                        });
                });

            modelBuilder.Entity("Interdisciplinary.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableTickets")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShowId");

                    b.HasIndex("AdminId");

                    b.HasIndex("GenreId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            ShowId = 1,
                            AdminId = 1,
                            AvailableTickets = 230,
                            Date = new DateTime(2021, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            ImageUrl = "https://i.ibb.co/zPGkR3q/la-traviata.png",
                            Price = 189,
                            Title = "La traviata"
                        },
                        new
                        {
                            ShowId = 2,
                            AdminId = 2,
                            AvailableTickets = 451,
                            Date = new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImageUrl = "https://i.ibb.co/KhKHJv9/the-four-seasons.png",
                            Price = 169,
                            Title = "The four seasons"
                        });
                });

            modelBuilder.Entity("Interdisciplinary.Models.Show", b =>
                {
                    b.HasOne("Interdisciplinary.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interdisciplinary.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

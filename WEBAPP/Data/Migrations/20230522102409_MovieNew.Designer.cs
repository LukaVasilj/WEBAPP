﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WEBAPP.Context;

#nullable disable

namespace WEBAPP.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230522102409_MovieNew")]
    partial class MovieNew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WEBAPP.Models.Genre", b =>
                {
                    b.Property<int>("genreid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("genreid"));

                    b.Property<string>("genrename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("genreid");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("WEBAPP.Models.Movie", b =>
                {
                    b.Property<int>("movieid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("movieid"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("director")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("genreid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("releasedate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("movieid");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("WEBAPP.Models.Showtime", b =>
                {
                    b.Property<int>("showtimeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("showtimeid"));

                    b.Property<DateTime>("endtime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("movieid")
                        .HasColumnType("integer");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("starttime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("theaterid")
                        .HasColumnType("integer");

                    b.HasKey("showtimeid");

                    b.HasIndex("movieid");

                    b.HasIndex("theaterid");

                    b.ToTable("showtimes");
                });

            modelBuilder.Entity("WEBAPP.Models.Theater", b =>
                {
                    b.Property<int>("theaterid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("theaterid"));

                    b.Property<int>("capacity")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("theaterid");

                    b.ToTable("theaters");
                });

            modelBuilder.Entity("WEBAPP.Models.Showtime", b =>
                {
                    b.HasOne("WEBAPP.Models.Movie", "movies")
                        .WithMany("showtimes")
                        .HasForeignKey("movieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEBAPP.Models.Theater", "theaters")
                        .WithMany("showtimes")
                        .HasForeignKey("theaterid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movies");

                    b.Navigation("theaters");
                });

            modelBuilder.Entity("WEBAPP.Models.Movie", b =>
                {
                    b.Navigation("showtimes");
                });

            modelBuilder.Entity("WEBAPP.Models.Theater", b =>
                {
                    b.Navigation("showtimes");
                });
#pragma warning restore 612, 618
        }
    }
}

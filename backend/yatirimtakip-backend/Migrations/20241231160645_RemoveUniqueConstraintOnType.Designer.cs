﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using yatirimtakip_backend.Data;

#nullable disable

namespace yatirimtakip_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241231160645_RemoveUniqueConstraintOnType")]
    partial class RemoveUniqueConstraintOnType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("yatirimtakip_backend.Models.Investment", b =>
                {
                    b.Property<int>("InvestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InvestID"));

                    b.Property<int>("StockID")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitAmount")
                        .HasColumnType("integer");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("InvestID");

                    b.HasIndex("StockID");

                    b.HasIndex("UserID");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("yatirimtakip_backend.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Close")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("High")
                        .HasPrecision(18, 2)
                        .HasColumnType("real");

                    b.Property<float>("Low")
                        .HasPrecision(18, 2)
                        .HasColumnType("real");

                    b.Property<float>("Open")
                        .HasPrecision(18, 2)
                        .HasColumnType("real");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("yatirimtakip_backend.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("yatirimtakip_backend.Models.Investment", b =>
                {
                    b.HasOne("yatirimtakip_backend.Models.Stock", "Stock")
                        .WithMany("Investments")
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("yatirimtakip_backend.Models.User", "User")
                        .WithMany("Investments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("yatirimtakip_backend.Models.Stock", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("yatirimtakip_backend.Models.User", b =>
                {
                    b.Navigation("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}
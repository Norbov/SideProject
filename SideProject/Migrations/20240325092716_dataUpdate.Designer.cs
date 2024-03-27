﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SideProject.Data;

#nullable disable

namespace SideProject.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240325092716_dataUpdate")]
    partial class dataUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("SideProject.Models.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("roles")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("userName");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("SideProject.Models.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("applicationUseruserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("fileFormat")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("user")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("applicationUseruserName");

                    b.ToTable("images");
                });

            modelBuilder.Entity("SideProject.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SideProject.Models.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("applicationUseruserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("fileFormat")
                        .HasColumnType("INTEGER");

                    b.Property<string>("user")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("video")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("applicationUseruserName");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("SideProject.Models.Entities.Image", b =>
                {
                    b.HasOne("SideProject.Models.Entities.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUseruserName");

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("SideProject.Models.Entities.Video", b =>
                {
                    b.HasOne("SideProject.Models.Entities.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUseruserName");

                    b.Navigation("applicationUser");
                });
#pragma warning restore 612, 618
        }
    }
}
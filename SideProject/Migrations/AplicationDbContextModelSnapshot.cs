﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SideProject.Data;

#nullable disable

namespace SideProject.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("SideProject.Models.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
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

            modelBuilder.Entity("SideProject.Models.Entities.UploadedDatas", b =>
                {
                    b.Property<string>("aplicationUseruserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("imageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("aplicationUseruserName");

                    b.ToTable("uploads");
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

            modelBuilder.Entity("SideProject.Models.Entities.Image", b =>
                {
                    b.HasOne("SideProject.Models.Entities.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUseruserName");

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("SideProject.Models.Entities.UploadedDatas", b =>
                {
                    b.HasOne("SideProject.Models.Entities.ApplicationUser", "aplicationUser")
                        .WithMany()
                        .HasForeignKey("aplicationUseruserName");

                    b.Navigation("aplicationUser");
                });
#pragma warning restore 612, 618
        }
    }
}

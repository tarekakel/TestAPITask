﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Presentation;

#nullable disable

namespace Presistence.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.DownloadType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DownloadTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(345),
                            IsDeleted = false,
                            TypeName = "A4Pdf"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(364),
                            IsDeleted = false,
                            TypeName = "MobilePdf"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(367),
                            IsDeleted = false,
                            TypeName = "JPG"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContentText = "book2.jpg",
                            ContentTitle = "book2.jpg",
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(704),
                            ImagePath = "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\book2.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            ContentText = "books.jpg",
                            ContentTitle = "books.jpg",
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(717),
                            ImagePath = "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\books.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            ContentText = "panda.jpg",
                            ContentTitle = "panda.jpg",
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(728),
                            ImagePath = "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\panda.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            ContentText = "panda2.png",
                            ContentTitle = "panda2.png",
                            CreateDate = new DateTime(2022, 12, 23, 23, 14, 32, 848, DateTimeKind.Local).AddTicks(736),
                            ImagePath = "C:\\Users\\ASUS\\source\\repos\\TaskTestAppAPI\\TaskTestAppAPI\\wwwRoot\\images\\panda2.png",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.PhotoDownloadType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DownloadTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DownloadTypeId");

                    b.HasIndex("PhotoId");

                    b.ToTable("PhotoDownloadTypes");
                });

            modelBuilder.Entity("Domain.Entities.PhotoDownloadType", b =>
                {
                    b.HasOne("Domain.Entities.DownloadType", "DownloadType")
                        .WithMany("PhotoDownloadTypes")
                        .HasForeignKey("DownloadTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Photo", "Photo")
                        .WithMany("PhotoDownloadTypes")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DownloadType");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Domain.Entities.DownloadType", b =>
                {
                    b.Navigation("PhotoDownloadTypes");
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.Navigation("PhotoDownloadTypes");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RB.TBC.FinalProject.Domain.Data;

#nullable disable

namespace RB.TBC.FinalProject.Domain.Migrations
{
    [DbContext(typeof(TbcDbContext))]
    partial class TbcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("VolumeInfoId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VolumeInfoId")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.ImageLinks", b =>
                {
                    b.Property<string>("ImageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("VolumeInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ImageId");

                    b.ToTable("ImageLinks");
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.VolumeInfo", b =>
                {
                    b.Property<string>("VolumeInfoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("authors")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("imageLinksId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("VolumeInfoId");

                    b.HasIndex("imageLinksId")
                        .IsUnique();

                    b.ToTable("VolumeInfo");
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.Book", b =>
                {
                    b.HasOne("RB.TBC.FinalProject.Domain.Entitites.VolumeInfo", "VolumeInfo")
                        .WithOne("Book")
                        .HasForeignKey("RB.TBC.FinalProject.Domain.Entitites.Book", "VolumeInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VolumeInfo");
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.VolumeInfo", b =>
                {
                    b.HasOne("RB.TBC.FinalProject.Domain.Entitites.ImageLinks", "imageLinks")
                        .WithOne("info")
                        .HasForeignKey("RB.TBC.FinalProject.Domain.Entitites.VolumeInfo", "imageLinksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("imageLinks");
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.ImageLinks", b =>
                {
                    b.Navigation("info")
                        .IsRequired();
                });

            modelBuilder.Entity("RB.TBC.FinalProject.Domain.Entitites.VolumeInfo", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

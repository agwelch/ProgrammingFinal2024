﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammingFinal2024.Models;

#nullable disable

namespace ProgrammingFinal2024.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241213031031_SeedDataUpdate")]
    partial class SeedDataUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ProgrammingFinal2024.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("ReceiverID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SenderID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MessageID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ProgrammingFinal2024.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProgrammingFinal2024.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<int>("ParticipatingProjectsProjectID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersUserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParticipatingProjectsProjectID", "UsersUserID");

                    b.HasIndex("UsersUserID");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("ProgrammingFinal2024.Message", b =>
                {
                    b.HasOne("ProgrammingFinal2024.Models.User", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProgrammingFinal2024.Models.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("ProgrammingFinal2024.Project", null)
                        .WithMany()
                        .HasForeignKey("ParticipatingProjectsProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammingFinal2024.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingFinal2024.Models.User", b =>
                {
                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
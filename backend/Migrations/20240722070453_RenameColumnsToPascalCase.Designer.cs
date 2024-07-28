﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.context;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(CubeDbContext))]
    [Migration("20240722070453_RenameColumnsToPascalCase")]
    partial class RenameColumnsToPascalCase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("backend.entities.Archetype", b =>
                {
                    b.Property<int>("ArchetypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ArchetypeId");

                    b.ToTable("Archetypes");
                });

            modelBuilder.Entity("backend.entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OracleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("backend.entities.CardInArchetype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArchetypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArchetypeId");

                    b.HasIndex("CardId");

                    b.ToTable("CardsInArchetype");
                });

            modelBuilder.Entity("backend.entities.CardInCube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CubeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("CubeId");

                    b.ToTable("CardsInCube");
                });

            modelBuilder.Entity("backend.entities.Cube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CubeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cubes");
                });

            modelBuilder.Entity("backend.entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.entities.CardInArchetype", b =>
                {
                    b.HasOne("backend.entities.Archetype", "Archetype")
                        .WithMany("CardsInArchetype")
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archetype");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("backend.entities.CardInCube", b =>
                {
                    b.HasOne("backend.entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.entities.Cube", "Cube")
                        .WithMany("CardsInCube")
                        .HasForeignKey("CubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Cube");
                });

            modelBuilder.Entity("backend.entities.Cube", b =>
                {
                    b.HasOne("backend.entities.User", "User")
                        .WithMany("Cubes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.entities.Archetype", b =>
                {
                    b.Navigation("CardsInArchetype");
                });

            modelBuilder.Entity("backend.entities.Cube", b =>
                {
                    b.Navigation("CardsInCube");
                });

            modelBuilder.Entity("backend.entities.User", b =>
                {
                    b.Navigation("Cubes");
                });
#pragma warning restore 612, 618
        }
    }
}

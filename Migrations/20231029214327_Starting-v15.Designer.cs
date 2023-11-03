﻿// <auto-generated />
using System;
using Challenge03.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge03.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231029214327_Starting-v15")]
    partial class Startingv15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Challenge03.Models.Baralho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Baralhos");
                });

            modelBuilder.Entity("Challenge03.Models.Batalha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Card_AId")
                        .HasColumnType("int");

                    b.Property<int?>("Card_AId1")
                        .HasColumnType("int");

                    b.Property<int?>("Card_BId")
                        .HasColumnType("int");

                    b.Property<string>("Escolha_A")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escolha_B")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogBatalha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Player_AId")
                        .HasColumnType("int");

                    b.Property<int?>("Player_AId1")
                        .HasColumnType("int");

                    b.Property<int?>("Player_BId")
                        .HasColumnType("int");

                    b.Property<int?>("VencedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Card_AId")
                        .IsUnique()
                        .HasFilter("[Card_AId] IS NOT NULL");

                    b.HasIndex("Card_AId1");

                    b.HasIndex("Player_AId")
                        .IsUnique()
                        .HasFilter("[Player_AId] IS NOT NULL");

                    b.HasIndex("Player_AId1");

                    b.HasIndex("VencedorId");

                    b.ToTable("Batalhas");
                });

            modelBuilder.Entity("Challenge03.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Agilidade")
                        .HasColumnType("int");

                    b.Property<string>("Assinatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BaralhoId")
                        .HasColumnType("int");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Defesa")
                        .HasColumnType("int");

                    b.Property<string>("Elemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Forca")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SP")
                        .HasColumnType("int");

                    b.Property<string>("TextoParaImagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaralhoId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Challenge03.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BaralhoId")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Challenge03.Models.Baralho", b =>
                {
                    b.HasOne("Challenge03.Models.Player", "Player")
                        .WithOne("Baralho")
                        .HasForeignKey("Challenge03.Models.Baralho", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Challenge03.Models.Batalha", b =>
                {
                    b.HasOne("Challenge03.Models.Card", "Card_B")
                        .WithOne()
                        .HasForeignKey("Challenge03.Models.Batalha", "Card_AId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Challenge03.Models.Card", "Card_A")
                        .WithMany()
                        .HasForeignKey("Card_AId1");

                    b.HasOne("Challenge03.Models.Player", "Player_B")
                        .WithOne()
                        .HasForeignKey("Challenge03.Models.Batalha", "Player_AId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Challenge03.Models.Player", "Player_A")
                        .WithMany()
                        .HasForeignKey("Player_AId1");

                    b.HasOne("Challenge03.Models.Card", "Vencedor")
                        .WithMany()
                        .HasForeignKey("VencedorId");

                    b.Navigation("Card_A");

                    b.Navigation("Card_B");

                    b.Navigation("Player_A");

                    b.Navigation("Player_B");

                    b.Navigation("Vencedor");
                });

            modelBuilder.Entity("Challenge03.Models.Card", b =>
                {
                    b.HasOne("Challenge03.Models.Baralho", "Baralho")
                        .WithMany("Cards")
                        .HasForeignKey("BaralhoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Baralho");
                });

            modelBuilder.Entity("Challenge03.Models.Baralho", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("Challenge03.Models.Player", b =>
                {
                    b.Navigation("Baralho");
                });
#pragma warning restore 612, 618
        }
    }
}

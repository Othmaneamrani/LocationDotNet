﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Compte", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("comptes");
                });

            modelBuilder.Entity("DAL.Models.Demande", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("compteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("dateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateFin")
                        .HasColumnType("datetime2");

                    b.Property<double>("prixTotal")
                        .HasColumnType("float");

                    b.Property<long>("vehiculeId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("compteId");

                    b.HasIndex("vehiculeId");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("DAL.Models.Favoris", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("compteId")
                        .HasColumnType("bigint");

                    b.Property<long>("vehiculeId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("compteId");

                    b.HasIndex("vehiculeId");

                    b.ToTable("favoris");
                });

            modelBuilder.Entity("DAL.Models.Vehicule", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("annonce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("kilometrage")
                        .HasColumnType("float");

                    b.Property<string>("marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nombreSieges")
                        .HasColumnType("int");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("prix")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeMoteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("vehicules");
                });

            modelBuilder.Entity("DAL.Models.Demande", b =>
                {
                    b.HasOne("DAL.Models.Vehicule", "vehicule")
                        .WithMany("demandes")
                        .HasForeignKey("compteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Compte", "compte")
                        .WithMany("demandes")
                        .HasForeignKey("vehiculeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("compte");

                    b.Navigation("vehicule");
                });

            modelBuilder.Entity("DAL.Models.Favoris", b =>
                {
                    b.HasOne("DAL.Models.Compte", "compte")
                        .WithMany("favoris")
                        .HasForeignKey("compteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Vehicule", "vehicule")
                        .WithMany("favoris")
                        .HasForeignKey("vehiculeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("compte");

                    b.Navigation("vehicule");
                });

            modelBuilder.Entity("DAL.Models.Compte", b =>
                {
                    b.Navigation("demandes");

                    b.Navigation("favoris");
                });

            modelBuilder.Entity("DAL.Models.Vehicule", b =>
                {
                    b.Navigation("demandes");

                    b.Navigation("favoris");
                });
#pragma warning restore 612, 618
        }
    }
}

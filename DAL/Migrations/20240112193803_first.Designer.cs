﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240112193803_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Client", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("DAL.Models.Demande", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("clientId")
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

                    b.HasIndex("clientId");

                    b.HasIndex("vehiculeId");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("DAL.Models.Vehicule", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<double>("kilometrage")
                        .HasColumnType("float");

                    b.Property<string>("marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nombreSieges")
                        .HasColumnType("int");

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
                    b.HasOne("DAL.Models.Client", "client")
                        .WithMany("demandes")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Vehicule", "vehicule")
                        .WithMany("demandes")
                        .HasForeignKey("vehiculeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("vehicule");
                });

            modelBuilder.Entity("DAL.Models.Client", b =>
                {
                    b.Navigation("demandes");
                });

            modelBuilder.Entity("DAL.Models.Vehicule", b =>
                {
                    b.Navigation("demandes");
                });
#pragma warning restore 612, 618
        }
    }
}

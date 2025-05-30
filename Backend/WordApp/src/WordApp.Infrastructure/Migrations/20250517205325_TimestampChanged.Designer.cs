﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WordApp.Infrastructure.Context;

#nullable disable

namespace WordApp.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250517205325_TimestampChanged")]
    partial class TimestampChanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WordApp.Domain.Synonms.Synonm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ForeignWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TranslatedWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("WordId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("Synonms");
                });

            modelBuilder.Entity("WordApp.Domain.Words.Word", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ForeignWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("KnownType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastCheckedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TranslatedWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("WordApp.Domain.Synonms.Synonm", b =>
                {
                    b.HasOne("WordApp.Domain.Words.Word", "Word")
                        .WithMany("Synonms")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("WordApp.Domain.Words.Word", b =>
                {
                    b.Navigation("Synonms");
                });
#pragma warning restore 612, 618
        }
    }
}

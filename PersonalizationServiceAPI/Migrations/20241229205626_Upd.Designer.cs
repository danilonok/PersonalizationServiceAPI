﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalizationServiceAPI.Data;

#nullable disable

namespace PersonalizationServiceAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241229205626_Upd")]
    partial class Upd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonalizationServiceAPI.Models.PersonalizationSettings", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<bool>("EmailNotifications")
                        .HasColumnType("boolean");

                    b.Property<bool>("NightMode")
                        .HasColumnType("boolean");

                    b.HasKey("UserId");

                    b.ToTable("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}

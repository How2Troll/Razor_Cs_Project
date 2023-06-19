﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPagesCurrency.Data;

#nullable disable

namespace RazorPagesCurrency.Migrations
{
    [DbContext(typeof(RazorPagesCurrencyContext))]
    [Migration("20230619132448_UpdateLastThirtyDaysRate")]
    partial class UpdateLastThirtyDaysRate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("RazorPagesCurrency.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("decimal(4, 6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("RazorPagesCurrency.Models.LastThirtyDaysRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ExchangeRateElement")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("LastThirtyDaysRates");
                });

            modelBuilder.Entity("RazorPagesCurrency.Models.LastThirtyDaysRate", b =>
                {
                    b.HasOne("RazorPagesCurrency.Models.Currency", null)
                        .WithMany("ListExchange")
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("RazorPagesCurrency.Models.Currency", b =>
                {
                    b.Navigation("ListExchange");
                });
#pragma warning restore 612, 618
        }
    }
}
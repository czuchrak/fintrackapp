﻿// <auto-generated />
using System;
using Fintrack.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fintrack.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221117151450_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fintrack.Database.Entities.Currency", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Code");

                    b.ToTable("Currencies", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.ExchangeRate", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(0);

                    b.Property<string>("Currency")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(8,6)");

                    b.HasKey("Date", "Currency");

                    b.ToTable("ExchangeRates", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Logs", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExchangeRateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NetWorthEntries", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthEntryPart", b =>
                {
                    b.Property<Guid>("NetWorthPartId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid>("NetWorthEntryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NetWorthPartId", "NetWorthEntryId");

                    b.HasIndex("NetWorthEntryId");

                    b.ToTable("NetWorthEntryParts", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthGoal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ReturnRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NetWorthGoals", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthGoalPart", b =>
                {
                    b.Property<Guid>("NetWorthPartId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid>("NetWorthGoalId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.HasKey("NetWorthPartId", "NetWorthGoalId");

                    b.HasIndex("NetWorthGoalId");

                    b.ToTable("NetWorthGoalParts", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NetWorthParts", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Notifications", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Properties", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.PropertyCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsCost")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PropertyCategories", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.PropertyTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyTransactions", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Setting", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Settings", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("LastActivity")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NewMonthEmailEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("NewsEmailEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("VerificationMailSent")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.UserNotification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(1);

                    b.HasKey("NotificationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotifications", "dbo");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthEntry", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.User", "User")
                        .WithMany("NetWorthEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthEntryPart", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.NetWorthEntry", "NetWorthEntry")
                        .WithMany("EntryParts")
                        .HasForeignKey("NetWorthEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fintrack.Database.Entities.NetWorthPart", "NetWorthPart")
                        .WithMany("EntryParts")
                        .HasForeignKey("NetWorthPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetWorthEntry");

                    b.Navigation("NetWorthPart");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthGoal", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.User", "User")
                        .WithMany("NetWorthGoals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthGoalPart", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.NetWorthGoal", "NetWorthGoal")
                        .WithMany("GoalParts")
                        .HasForeignKey("NetWorthGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fintrack.Database.Entities.NetWorthPart", "NetWorthPart")
                        .WithMany("GoalParts")
                        .HasForeignKey("NetWorthPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetWorthGoal");

                    b.Navigation("NetWorthPart");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthPart", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.User", "User")
                        .WithMany("NetWorthParts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Property", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.User", "User")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.PropertyTransaction", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.Property", "Property")
                        .WithMany("Transactions")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.UserNotification", b =>
                {
                    b.HasOne("Fintrack.Database.Entities.Notification", "Notification")
                        .WithMany("UserNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fintrack.Database.Entities.User", "User")
                        .WithMany("UserNotifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthEntry", b =>
                {
                    b.Navigation("EntryParts");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthGoal", b =>
                {
                    b.Navigation("GoalParts");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.NetWorthPart", b =>
                {
                    b.Navigation("EntryParts");

                    b.Navigation("GoalParts");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Notification", b =>
                {
                    b.Navigation("UserNotifications");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.Property", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Fintrack.Database.Entities.User", b =>
                {
                    b.Navigation("NetWorthEntries");

                    b.Navigation("NetWorthGoals");

                    b.Navigation("NetWorthParts");

                    b.Navigation("Properties");

                    b.Navigation("UserNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}

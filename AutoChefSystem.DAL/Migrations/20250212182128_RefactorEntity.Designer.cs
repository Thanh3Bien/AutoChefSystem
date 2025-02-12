﻿// <auto-generated />
using System;
using AutoChefSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoChefSystem.DAL.Migrations
{
    [DbContext(typeof(AutoChefSystemContext))]
    [Migration("20250212182128_RefactorEntity")]
    partial class RefactorEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Broth", b =>
                {
                    b.Property<int>("BrothsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrothsId"));

                    b.Property<string>("BrothsName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("BrothsId")
                        .HasName("PK__Broths__9F37327F45A2D929");

                    b.ToTable("Broths");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Customer", b =>
                {
                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Phone")
                        .HasName("PK__Customer__5C7E359F03449E5C");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishId"));

                    b.Property<int?>("BrothsId")
                        .HasColumnType("int");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("NoodlesId")
                        .HasColumnType("int");

                    b.HasKey("DishId")
                        .HasName("PK__Dish__18834F50F2AD62CC");

                    b.HasIndex("BrothsId");

                    b.HasIndex("NoodlesId");

                    b.ToTable("Dish", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("FeedbackId")
                        .HasName("PK__Feedback__6A4BEDD6B680CDB9");

                    b.HasIndex("Phone");

                    b.HasIndex(new[] { "OrderId" }, "UQ_FeedbackOrder")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IngredientId")
                        .HasName("PK__Ingredie__BEAEB25A2BFFBF74");

                    b.ToTable("Ingredient", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Noodle", b =>
                {
                    b.Property<int>("NoodlesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoodlesId"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("NoodlesName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NoodlesId")
                        .HasName("PK__Noodles__A38C5092C0E02B25");

                    b.ToTable("Noodles");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("DishId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderId")
                        .HasName("PK__Order__C3905BCF668B17E3");

                    b.HasIndex("DishId");

                    b.HasIndex("Phone");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE1AA8C07C01");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId")
                        .HasName("PK__User__1788CC4C449E6D91");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Dish", b =>
                {
                    b.HasOne("AutoChefSystem.DAL.Entities.Broth", "Broths")
                        .WithMany("Dishes")
                        .HasForeignKey("BrothsId")
                        .HasConstraintName("FK__Dish__BrothsId__59FA5E80");

                    b.HasOne("AutoChefSystem.DAL.Entities.Noodle", "Noodles")
                        .WithMany("Dishes")
                        .HasForeignKey("NoodlesId")
                        .HasConstraintName("FK__Dish__NoodlesId__59063A47");

                    b.Navigation("Broths");

                    b.Navigation("Noodles");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Feedback", b =>
                {
                    b.HasOne("AutoChefSystem.DAL.Entities.Order", "Order")
                        .WithOne("Feedback")
                        .HasForeignKey("AutoChefSystem.DAL.Entities.Feedback", "OrderId")
                        .HasConstraintName("FK__Feedback__OrderI__70DDC3D8");

                    b.HasOne("AutoChefSystem.DAL.Entities.Customer", "PhoneNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("Phone")
                        .HasConstraintName("FK__Feedback__Phone__6FE99F9F");

                    b.Navigation("Order");

                    b.Navigation("PhoneNavigation");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Order", b =>
                {
                    b.HasOne("AutoChefSystem.DAL.Entities.Dish", "Dish")
                        .WithMany("Orders")
                        .HasForeignKey("DishId")
                        .HasConstraintName("FK__Order__DishId__14270015");

                    b.HasOne("AutoChefSystem.DAL.Entities.Customer", "PhoneNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Phone")
                        .HasConstraintName("FK__Order__Phone__693CA210");

                    b.Navigation("Dish");

                    b.Navigation("PhoneNavigation");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.User", b =>
                {
                    b.HasOne("AutoChefSystem.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__User__RoleId__4CA06362");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Broth", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Customer", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Dish", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Noodle", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Order", b =>
                {
                    b.Navigation("Feedback");
                });

            modelBuilder.Entity("AutoChefSystem.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

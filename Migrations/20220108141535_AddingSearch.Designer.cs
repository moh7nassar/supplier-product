// <auto-generated />
using System;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProject.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220108141535_AddingSearch")]
    partial class AddingSearch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalProject.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("tblOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderDate = new DateTime(2022, 1, 6, 16, 15, 34, 757, DateTimeKind.Local).AddTicks(5037),
                            ProductId = 1,
                            Quantity = 1,
                            Status = 0,
                            SupplierId = 1,
                            TotalPrice = 850.0
                        },
                        new
                        {
                            OrderId = 2,
                            OrderDate = new DateTime(2022, 1, 3, 16, 15, 34, 760, DateTimeKind.Local).AddTicks(5637),
                            ProductId = 2,
                            Quantity = 1,
                            Status = 2,
                            SupplierId = 2,
                            TotalPrice = 450.0
                        },
                        new
                        {
                            OrderId = 3,
                            OrderDate = new DateTime(2022, 1, 7, 16, 15, 34, 760, DateTimeKind.Local).AddTicks(5682),
                            ProductId = 3,
                            Quantity = 1,
                            Status = 1,
                            SupplierId = 3,
                            TotalPrice = 150.0
                        },
                        new
                        {
                            OrderId = 4,
                            OrderDate = new DateTime(2021, 12, 29, 16, 15, 34, 760, DateTimeKind.Local).AddTicks(5690),
                            ProductId = 2,
                            Quantity = 1,
                            Status = 3,
                            SupplierId = 1,
                            TotalPrice = 390.0
                        });
                });

            modelBuilder.Entity("FinalProject.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nvarchar(40)");

                    b.HasKey("ProductId");

                    b.ToTable("tblProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Photo = "/images/headphone.png",
                            Price = 200.0,
                            Title = "Headphones"
                        },
                        new
                        {
                            ProductId = 2,
                            Photo = "/images/laptop.jpg",
                            Price = 800.0,
                            Title = "Laptop"
                        },
                        new
                        {
                            ProductId = 3,
                            Photo = "/images/book.png",
                            Price = 30.0,
                            Title = "Book"
                        });
                });

            modelBuilder.Entity("FinalProject.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("tblSuppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Address = "New York",
                            Country = "USA",
                            Email = "help@sony.com",
                            Name = "Sony",
                            Phone = "0927420193"
                        },
                        new
                        {
                            SupplierId = 2,
                            Address = "Seoul",
                            Country = "Korea",
                            Email = "help@samsung.com",
                            Name = "Samsung",
                            Phone = "0291728159"
                        },
                        new
                        {
                            SupplierId = 3,
                            Address = "Amman",
                            Country = "Jordan",
                            Email = "help@dna.com",
                            Name = "DNA",
                            Phone = "0777777777"
                        });
                });

            modelBuilder.Entity("FinalProject.Models.Order", b =>
                {
                    b.HasOne("FinalProject.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.Supplier", "Supplier")
                        .WithMany("Orders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("FinalProject.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FinalProject.Models.Supplier", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

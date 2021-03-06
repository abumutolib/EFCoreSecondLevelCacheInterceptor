﻿// <auto-generated />
using EFCoreSecondLevelCacheInterceptor.Tests.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200208105314_V2020_02_08_1422")]
    partial class V2020_02_08_1422
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            BlogId = 1,
                            Url = "https://site1.com"
                        },
                        new
                        {
                            BlogId = 2,
                            Url = "https://site2.com"
                        });
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.BlogData", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("BlogData");
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("post_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasDiscriminator<string>("post_type").HasValue("post_base");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 1,
                            Title = "Post1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 1,
                            Title = "Post2",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ProductNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductName")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IsActive = false,
                            Notes = "Notes ...",
                            ProductName = "Product4",
                            ProductNumber = "004",
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            IsActive = true,
                            Notes = "Notes ...",
                            ProductName = "Product1",
                            ProductNumber = "001",
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            IsActive = true,
                            Notes = "Notes ...",
                            ProductName = "Product2",
                            ProductNumber = "002",
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            IsActive = true,
                            Notes = "Notes ...",
                            ProductName = "Product3",
                            ProductNumber = "003",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tag4"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tag1"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tag2"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tag3"
                        });
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.TagProduct", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("ProductProductId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "ProductProductId");

                    b.HasIndex("ProductProductId");

                    b.HasIndex("TagId");

                    b.ToTable("TagProducts");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            ProductProductId = 1
                        },
                        new
                        {
                            TagId = 2,
                            ProductProductId = 2
                        },
                        new
                        {
                            TagId = 3,
                            ProductProductId = 3
                        },
                        new
                        {
                            TagId = 4,
                            ProductProductId = 4
                        });
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User1",
                            UserStatus = 0
                        });
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Page", b =>
                {
                    b.HasBaseType("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Post");

                    b.HasDiscriminator().HasValue("post_page");
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Post", b =>
                {
                    b.HasOne("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Product", b =>
                {
                    b.HasOne("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.TagProduct", b =>
                {
                    b.HasOne("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Product", "Product")
                        .WithMany("TagProducts")
                        .HasForeignKey("ProductProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreSecondLevelCacheInterceptor.Tests.DataLayer.Entities.Tag", "Tag")
                        .WithMany("TagProducts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

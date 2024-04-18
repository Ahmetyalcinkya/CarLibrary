﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CarBookContext))]
    partial class CarBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AboutID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Domain.Entities.AppRole", b =>
                {
                    b.Property<int>("AppRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppRoleID"));

                    b.Property<string>("AppRoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AppRoleID");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Property<int>("AppUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppUserID"));

                    b.Property<int>("AppRoleID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AppUserID");

                    b.HasIndex("AppRoleID");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Domain.Entities.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BannerID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BannerID");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlogID"));

                    b.Property<int>("AuthorID")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BlogID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BrandID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarID"));

                    b.Property<int>("BrandID")
                        .HasColumnType("integer");

                    b.Property<string>("CarCoverImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListCoverImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Luggage")
                        .HasColumnType("smallint");

                    b.Property<int>("MileAge")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Seat")
                        .HasColumnType("smallint");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarID");

                    b.HasIndex("BrandID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.CarDescription", b =>
                {
                    b.Property<int>("CarDescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarDescriptionID"));

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarDescriptionID");

                    b.HasIndex("CarID");

                    b.ToTable("CarDescriptions");
                });

            modelBuilder.Entity("Domain.Entities.CarFeature", b =>
                {
                    b.Property<int>("CarFeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarFeatureID"));

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<int>("FeatureID")
                        .HasColumnType("integer");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("boolean");

                    b.HasKey("CarFeatureID");

                    b.HasIndex("CarID");

                    b.HasIndex("FeatureID");

                    b.ToTable("CarFeatures");
                });

            modelBuilder.Entity("Domain.Entities.CarPricing", b =>
                {
                    b.Property<int>("CarPricingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarPricingID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<int>("PricingID")
                        .HasColumnType("integer");

                    b.HasKey("CarPricingID");

                    b.HasIndex("CarID");

                    b.HasIndex("PricingID");

                    b.ToTable("CarPricings");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentID"));

                    b.Property<int>("BlogID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CommentID");

                    b.HasIndex("BlogID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Domain.Entities.Feature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FeatureID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FeatureID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Domain.Entities.FooterAddress", b =>
                {
                    b.Property<int>("FooterAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FooterAddressID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FooterAddressID");

                    b.ToTable("FooterAddresses");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entities.Pricing", b =>
                {
                    b.Property<int>("PricingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PricingID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PricingID");

                    b.ToTable("Pricings");
                });

            modelBuilder.Entity("Domain.Entities.RentACar", b =>
                {
                    b.Property<int>("RentACarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RentACarID"));

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("boolean");

                    b.HasKey("RentACarID");

                    b.HasIndex("CarID");

                    b.HasIndex("LocationID");

                    b.ToTable("RentACars");
                });

            modelBuilder.Entity("Domain.Entities.RentACarProcess", b =>
                {
                    b.Property<int>("RentACarProcessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RentACarProcessID"));

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DropOffDate")
                        .HasColumnType("Date");

                    b.Property<string>("DropOffDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DropOffLocation")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("DropOffTime")
                        .HasColumnType("interval");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("Date");

                    b.Property<string>("PickUpDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PickUpLocation")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("PickUpTime")
                        .HasColumnType("interval");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("RentACarProcessID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerID");

                    b.ToTable("RentACarProcess");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DriverLicenceYear")
                        .HasColumnType("integer");

                    b.Property<int?>("DropOffLocationID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PickUpLocationID")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReservationID");

                    b.HasIndex("CarID");

                    b.HasIndex("DropOffLocationID");

                    b.HasIndex("PickUpLocationID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewID"));

                    b.Property<int>("CarID")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReviewID");

                    b.HasIndex("CarID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Domain.Entities.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SocialMediaID"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SocialMediaID");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("Domain.Entities.TagCloud", b =>
                {
                    b.Property<int>("TagCloudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagCloudID"));

                    b.Property<int>("BlogID")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagCloudID");

                    b.HasIndex("BlogID");

                    b.ToTable("TagClouds");
                });

            modelBuilder.Entity("Domain.Entities.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TestimonialID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TestimonialID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.HasOne("Domain.Entities.AppRole", "AppRole")
                        .WithMany("AppUsers")
                        .HasForeignKey("AppRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.HasOne("Domain.Entities.Author", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.CarDescription", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CarDescriptions")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.CarFeature", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CarFeatures")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Feature", "Features")
                        .WithMany("CarFeatures")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Features");
                });

            modelBuilder.Entity("Domain.Entities.CarPricing", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CarPricings")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pricing", "Pricing")
                        .WithMany("CarPricings")
                        .HasForeignKey("PricingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Pricing");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Domain.Entities.RentACar", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("RentACars")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany("RentACars")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.RentACarProcess", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("Processes")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("Processes")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Location", "DropOffLocation")
                        .WithMany("DropOffReservations")
                        .HasForeignKey("DropOffLocationID");

                    b.HasOne("Domain.Entities.Location", "PickUpLocation")
                        .WithMany("PickUpReservations")
                        .HasForeignKey("PickUpLocationID");

                    b.Navigation("Car");

                    b.Navigation("DropOffLocation");

                    b.Navigation("PickUpLocation");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("Reviews")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.TagCloud", b =>
                {
                    b.HasOne("Domain.Entities.Blog", "Blog")
                        .WithMany("TagClouds")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Domain.Entities.AppRole", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TagClouds");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("CarDescriptions");

                    b.Navigation("CarFeatures");

                    b.Navigation("CarPricings");

                    b.Navigation("Processes");

                    b.Navigation("RentACars");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Navigation("Processes");
                });

            modelBuilder.Entity("Domain.Entities.Feature", b =>
                {
                    b.Navigation("CarFeatures");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Navigation("DropOffReservations");

                    b.Navigation("PickUpReservations");

                    b.Navigation("RentACars");
                });

            modelBuilder.Entity("Domain.Entities.Pricing", b =>
                {
                    b.Navigation("CarPricings");
                });
#pragma warning restore 612, 618
        }
    }
}

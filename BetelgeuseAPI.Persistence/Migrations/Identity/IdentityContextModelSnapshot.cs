﻿// <auto-generated />
using System;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    [DbContext(typeof(IdentityContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Role", "Identity");

                    b.HasData(
                        new
                        {
                            Id = "6c2727da-48d4-45a9-8751-aa7e23dd77c4",
                            Name = "Admin",
                            NormalizedName = "ADMİN"
                        },
                        new
                        {
                            Id = "f282779c-cf10-4ae6-b5db-e1ace92db4fd",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = "da823cb0-a9b9-4711-bf47-407df9e918eb",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("User", "Identity");

                    b.HasData(
                        new
                        {
                            Id = "da823cb0-a9b9-4711-bf47-407df9e918eb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2b84aad6-7539-4494-b2af-c55a41ddfd2a",
                            Email = "student@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT@GMAIL.COM",
                            NormalizedUserName = "STUDENT@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                            PhoneNumberConfirmed = true,
                            TwoFactorEnabled = false,
                            UserName = "student@gmail.com"
                        },
                        new
                        {
                            Id = "f282779c-cf10-4ae6-b5db-e1ace92db4fd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ab011d01-90ac-46a0-bf83-ca66d80289ef",
                            Email = "moderator@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MODERATOR@GMAIL.COM",
                            NormalizedUserName = "MODERATOR@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                            PhoneNumberConfirmed = true,
                            TwoFactorEnabled = false,
                            UserName = "moderator@gmail.com"
                        });
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("RefreshToken", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.UserAccountEducation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserAccountEducations", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.UserAccountExperiences", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Experiences")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserAccountExperiences", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.UserAccountInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<bool>("EmailNews")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("TimeZone")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("UserAccountInformation", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.AllUserSkills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCheck")
                        .HasColumnType("boolean");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("AllUserSkills", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.BlogCategories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("BlogCategories", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.Blogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BlogCategoriesID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlogImageID")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Keywords")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("BlogCategoriesID");

                    b.HasIndex("BlogImageID");

                    b.ToTable("Blogs", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("File", "Identity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("File");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserAccountAbout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("UserAccountInformationAbout", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserSkills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AllUserSkillsId")
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCheck")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AllUserSkillsId")
                        .IsUnique();

                    b.HasIndex("AppUserId");

                    b.ToTable("UserSkills", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");

                    b.HasData(
                        new
                        {
                            UserId = "f282779c-cf10-4ae6-b5db-e1ace92db4fd",
                            RoleId = "f282779c-cf10-4ae6-b5db-e1ace92db4fd"
                        },
                        new
                        {
                            UserId = "da823cb0-a9b9-4711-bf47-407df9e918eb",
                            RoleId = "da823cb0-a9b9-4711-bf47-407df9e918eb"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.BlogImage", b =>
                {
                    b.HasBaseType("BetelgeuseAPI.Domain.Entities.File");

                    b.HasIndex("AppUserId");

                    b.HasDiscriminator().HasValue("BlogImage");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserProfileBackgroundImage", b =>
                {
                    b.HasBaseType("BetelgeuseAPI.Domain.Entities.File");

                    b.HasIndex("AppUserId");

                    b.HasDiscriminator().HasValue("UserProfileBackgroundImage");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserProfileImage", b =>
                {
                    b.HasBaseType("BetelgeuseAPI.Domain.Entities.File");

                    b.HasIndex("AppUserId");

                    b.HasDiscriminator().HasValue("UserProfileImage");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.RefreshToken", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.UserAccountEducation", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany("UserAccountEducations")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.UserAccountExperiences", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany("UserAccountExperiences")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.UserAccountInformation", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithOne("UserAccountInformation")
                        .HasForeignKey("BetelgeuseAPI.Domain.Auth.UserAccountInformation", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.Blogs", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany("Blogs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BetelgeuseAPI.Domain.Entities.BlogCategories", "BlogCategories")
                        .WithMany()
                        .HasForeignKey("BlogCategoriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BetelgeuseAPI.Domain.Entities.BlogImage", "BlogImage")
                        .WithMany()
                        .HasForeignKey("BlogImageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("BlogCategories");

                    b.Navigation("BlogImage");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserAccountAbout", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", null)
                        .WithOne("UserAccountAbout")
                        .HasForeignKey("BetelgeuseAPI.Domain.Entities.UserAccountAbout", "AppUserId");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserSkills", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Entities.AllUserSkills", "AllUserSkills")
                        .WithOne("UserSkills")
                        .HasForeignKey("BetelgeuseAPI.Domain.Entities.UserSkills", "AllUserSkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany("UserSkills")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AllUserSkills");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.BlogImage", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserProfileBackgroundImage", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany("UserProfileBackgroundImage")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.UserProfileImage", b =>
                {
                    b.HasOne("BetelgeuseAPI.Domain.Auth.AppUser", "AppUser")
                        .WithMany("UserProfileImage")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Auth.AppUser", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserAccountAbout")
                        .IsRequired();

                    b.Navigation("UserAccountEducations");

                    b.Navigation("UserAccountExperiences");

                    b.Navigation("UserAccountInformation")
                        .IsRequired();

                    b.Navigation("UserProfileBackgroundImage");

                    b.Navigation("UserProfileImage");

                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("BetelgeuseAPI.Domain.Entities.AllUserSkills", b =>
                {
                    b.Navigation("UserSkills")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

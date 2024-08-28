﻿// <auto-generated />
using System;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    [DbContext(typeof(LmsContext))]
    [Migration("20240823205229_mig-6")]
    partial class mig6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lms.Entity.Accounts.RegisterStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Value")
                        .HasComment("For Registered Statuses");

                    b.HasKey("Id");

                    b.ToTable("RegisterStatuses", "library");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int?>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int?>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("Roles", "account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 776, DateTimeKind.Utc).AddTicks(2651),
                            CreatedId = 1,
                            UpdatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 776, DateTimeKind.Utc).AddTicks(2655),
                            UpdatedId = 1,
                            Value = "Admin"
                        });
                });

            modelBuilder.Entity("Lms.Entity.Accounts.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Email");

                    b.Property<string>("PassworHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", "account");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConfirmCode")
                        .HasColumnType("int")
                        .HasColumnName("ConfirmCode");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsConfirmPassword")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("LastName");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UserDetails", "account");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", "account");
                });

            modelBuilder.Entity("Lms.Entity.Books.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int?>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("LastName");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int?>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("Authors", "app");
                });

            modelBuilder.Entity("Lms.Entity.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int?>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Description")
                        .HasColumnType("nText");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasColumnName("Name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int?>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", "app", t =>
                        {
                            t.HasCheckConstraint("CK_Book_Price", "[Price] >= 0");
                        });
                });

            modelBuilder.Entity("Lms.Entity.Books.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("AuthorId1");

                    b.ToTable("BookAuthors", "app");
                });

            modelBuilder.Entity("Lms.Entity.Books.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int?>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int?>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.ToTable("Categories", "library");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1791),
                            CreatedId = 1,
                            UpdatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1794),
                            UpdatedId = 1,
                            Value = "Dram"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1798),
                            CreatedId = 1,
                            UpdatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1799),
                            UpdatedId = 1,
                            Value = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1884),
                            CreatedId = 1,
                            UpdatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1885),
                            UpdatedId = 1,
                            Value = "Dedectiv"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1887),
                            CreatedId = 1,
                            UpdatedDate = new DateTime(2024, 8, 23, 20, 52, 27, 783, DateTimeKind.Utc).AddTicks(1887),
                            UpdatedId = 1,
                            Value = "Fantastic"
                        });
                });

            modelBuilder.Entity("Lms.Entity.Commons.UploadedFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int?>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RelativePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int?>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UploadedFiles", "libraries");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.UserDetail", b =>
                {
                    b.HasOne("Lms.Entity.Accounts.RegisterStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lms.Entity.Accounts.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("Lms.Entity.Accounts.UserDetail", "UserId");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.UserRole", b =>
                {
                    b.HasOne("Lms.Entity.Accounts.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lms.Entity.Accounts.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lms.Entity.Books.Book", b =>
                {
                    b.HasOne("Lms.Entity.Books.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Lms.Entity.Books.BookAuthor", b =>
                {
                    b.HasOne("Lms.Entity.Books.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lms.Entity.Books.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Lms.Entity.Commons.UploadedFile", b =>
                {
                    b.HasOne("Lms.Entity.Books.Book", null)
                        .WithMany("UploadedFiles")
                        .HasForeignKey("BookId");

                    b.HasOne("Lms.Entity.Accounts.User", null)
                        .WithMany("UploadedFiles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Lms.Entity.Accounts.User", b =>
                {
                    b.Navigation("UploadedFiles");

                    b.Navigation("UserDetail");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Lms.Entity.Books.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Lms.Entity.Books.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("UploadedFiles");
                });
#pragma warning restore 612, 618
        }
    }
}

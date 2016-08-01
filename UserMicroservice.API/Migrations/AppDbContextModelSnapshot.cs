using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserMicroservice.API.Database;

namespace UserMicroservice.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserMicroservice.Data.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("CanCreatePermission");

                    b.Property<bool?>("CanCreateUser");

                    b.Property<bool?>("CanDeletePermission");

                    b.Property<bool?>("CanDeleteUser");

                    b.Property<bool?>("CanUpdatePermission");

                    b.Property<bool?>("CanUpdateUser");

                    b.Property<bool?>("CanViewPermission");

                    b.Property<bool?>("CanViewUser");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("UserMicroservice.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthToken");

                    b.Property<DateTime?>("AuthTokenExpiration");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PermissionsId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserMicroservice.Data.Models.User", b =>
                {
                    b.HasOne("UserMicroservice.Data.Models.Permission", "Permissions")
                        .WithMany()
                        .HasForeignKey("PermissionsId");
                });
        }
    }
}

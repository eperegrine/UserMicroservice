using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserMicroservice.API.Database;

namespace UserMicroservice.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160802234654_AddedGeneratedProps2")]
    partial class AddedGeneratedProps2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Email");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("PermissionId");

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserMicroservice.Data.Models.User", b =>
                {
                    b.HasOne("UserMicroservice.Data.Models.Permission", "Permissions")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

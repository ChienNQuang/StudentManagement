using StudentManagement.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentManagement.API.DbContexts
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options)
        : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Admin>().HasData(
                new
                {
                    Id = new Guid("ee69955b-c376-4664-9630-0f791cdc9d2c"),
                    Role = Role.Admin,
                    Username = "admin",
                    Password = "admin"
                },
                new
                {
                    Id = new Guid("deeb7602-2bed-4153-9d4c-76577103e1ea"),
                    Role = Role.Admin,
                    Username = "assmin",
                    Password = "123456"
                }
                );

            modelBuilder.Entity<Student>().HasData(
                new
                {
                    Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Nguyen Quang",
                    LastName = "Chien",
                    DateOfBirth = new DateTimeOffset(new DateTime(2003, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                    AverageScore = 8.0,
                    Address = "Ba Ria Vung Tau",
                    Role = Role.Student,
                    Username = "chiennqse171237",
                    Password = "Chien2346"
                },
                new
                {
                    Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Ngo Hoang",
                    LastName = "My",
                    DateOfBirth = new DateTimeOffset(new DateTime(2003, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                    AverageScore = 9.0,
                    Address = "Ba Ria Vung Tau",
                    Role = Role.Student,
                    Username = "hoangmy219",
                    Password = "123456"
                },
                new
                {
                    Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Nguyen Huy",
                    LastName = "Quy",
                    DateOfBirth = new DateTimeOffset(new DateTime(2003, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                    AverageScore = 8.0,
                    Address = "Ba Ria Vung Tau",
                    Role = Role.Student,
                    Username = "thienchode11347",
                    Password = "2142003"
                },
                new
                {
                    Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Do Quy",
                    LastName = "Duong",
                    DateOfBirth = new DateTimeOffset(new DateTime(2003, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                    AverageScore = 10.0,
                    Address = "Ba Ria Vung Tau",
                    Role = Role.Student,
                    Username = "doquyduong",
                    Password = "duongdoquy"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Role = table.Column<string>(maxLength: 10, nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Role = table.Column<string>(maxLength: 10, nullable: true),
                    Token = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    AverageScore = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("ee69955b-c376-4664-9630-0f791cdc9d2c"), "admin", "Admin", null, "admin" },
                    { new Guid("deeb7602-2bed-4153-9d4c-76577103e1ea"), "123456", "Admin", null, "assmin" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "AverageScore", "DateOfBirth", "FirstName", "LastName", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Ba Ria Vung Tau", 8.0, new DateTimeOffset(new DateTime(2003, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Nguyen Quang", "Chien", "Chien2346", "Student", null, "chiennqse171237" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Ba Ria Vung Tau", 9.0, new DateTimeOffset(new DateTime(2003, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Ngo Hoang", "My", "123456", "Student", null, "hoangmy219" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Ba Ria Vung Tau", 8.0, new DateTimeOffset(new DateTime(2003, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Nguyen Huy", "Quy", "2142003", "Student", null, "thienchode11347" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Ba Ria Vung Tau", 10.0, new DateTimeOffset(new DateTime(2003, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Do Quy", "Duong", "duongdoquy", "Student", null, "doquyduong" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

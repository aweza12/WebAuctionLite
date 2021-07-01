using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuctionLite.Migrations
{
    public partial class _initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d9");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Lots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Lots",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "160bad24-8fe2-4487-b8cc-1297a6b22453");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eac",
                column: "ConcurrencyStamp",
                value: "12894708-e804-434e-9e6f-ded516caa50f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d8bf3e0-692b-4ccc-ae71-607fac0cd39f", "AQAAAAEAACcQAAAAENssgratIrFhM+5k+L9BFAcE1jQPjYOA2hZRi0iWIA336s+6WholBym71qm9aPklRg==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MoneyAccount", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5abae320-5950-4876-bf5a-d483f0b2f59a", 0, "80e35444-3139-406d-bda0-6124f3049f6f", "ApplicationUser", "user001@email.com", true, null, null, false, null, 0m, "USER001@EMAIL.COM", "USER001", "AQAAAAEAACcQAAAAED/74WZrVOFOWL8t0vjEwameJDebhzg/ta4odbc5Hl5fM3Xws9eSAEhlj/a0p3jvMw==", null, false, "", false, "user001" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2021, 7, 1, 16, 17, 29, 218, DateTimeKind.Utc).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 7, 1, 16, 17, 29, 217, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 7, 1, 16, 17, 29, 218, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ApplicationUserId1",
                table: "Lots",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_AspNetUsers_ApplicationUserId1",
                table: "Lots",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_AspNetUsers_ApplicationUserId1",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_ApplicationUserId1",
                table: "Lots");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5abae320-5950-4876-bf5a-d483f0b2f59a");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Lots");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9fc50e9d-2731-4272-bb16-8a336a0a397a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eac",
                column: "ConcurrencyStamp",
                value: "a88d7f92-376d-4f24-90f9-111197aca003");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "06c72054-4050-4199-864e-5e1c4d11f6a0", "AQAAAAEAACcQAAAAEMyPhZUss4vlCnQmFdSl1zxmgzu+5xMN+gza579q5rrra3ZHIv/3IQNL+3ZeyBW4Ig==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3b62472e-4f66-49fa-a20f-e7685b9565d9", 0, "e5d18a15-6213-4da1-89ae-6057246acf18", "IdentityUser", "user001@email.com", true, false, null, "USER001@EMAIL.COM", "USER001", "AQAAAAEAACcQAAAAEDsiDg9hW4rLEwk+tkJBd1je1z/wTZDkhyq8CdiH22EMU/z4dm2cnqVJkgKK8EH4Iw==", null, false, "", false, "user001" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 30, 18, 31, 20, 221, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 30, 18, 31, 20, 221, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 30, 18, 31, 20, 221, DateTimeKind.Utc).AddTicks(9633));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BD.Data.Migrations
{
    public partial class AddTrackableToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DisabledAt",
                table: "Roles",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabledBy",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Roles",
                type: "datetime",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bd14b71d-2360-4eb8-9253-f365f5da30a6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f00206a7-f2b2-4b6f-a97b-49c7574fee8f", "AQAAAAEAACcQAAAAEFf7TCrCxcMIRZdq58bsTeMYSCMNZEZESs5xHRueC0egDIoYPtVdIC05HYZ0gu1UcA==", "2234d5dc-2565-4a77-9f2a-76e48fc44788" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(5542), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(5554) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6406), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6431), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6433) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6435), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6450), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6455), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6456) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6459), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6463), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6469), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6474), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6475) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6478), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6482), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6489), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6493), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6497), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6501), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6503) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6509) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6512), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6516), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6518) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6520), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6524), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6526) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6529), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6533), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6535) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6537), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6539) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6541), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6543) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6546), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6547) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6550), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6551) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6554), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6558), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6562), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6564) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6567), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6568) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6571), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6573) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6577), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6579) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DisabledAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DisabledBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0ce10c37-eba8-462c-a45f-5d3c5f39c1c8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4109642f-fa45-424d-9f06-cd9ab737dafc", "AQAAAAEAACcQAAAAEIYWDjDBjBb1/HwtsQSxPiyJuFK/ZMT3j5CjnGRKAXRVYZ0Jx7Zei5tlp7eyfkWOGg==", "2213a047-a3f6-4c91-bab0-6642e2693b9f" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(1484), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(1492) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2074), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2091), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2095), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2098), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2099) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2104), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2107), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2110), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2113), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2118), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2121), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2124), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2127), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2130), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2133), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2136), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2137) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2140), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2144), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2145) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2147), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2151), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2152) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2154), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2155) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2157), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2158) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2160), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2163), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2167), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2170), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2173), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2176), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2177) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2179), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2182), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2183) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2185), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2188), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2191), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2193) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2256), new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2257) });
        }
    }
}

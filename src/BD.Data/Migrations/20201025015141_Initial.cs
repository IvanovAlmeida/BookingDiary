using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BD.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    DisabledAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DisabledBy = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(180)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    DisabledAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    DisabledBy = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Type = table.Column<string>(type: "varchar(60)", nullable: false),
                    Value = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    DisabledAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DisabledBy = table.Column<int>(nullable: false),
                    Entry = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(100)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()"),
                    DisabledAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    DisabledBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashFlows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    DisabledAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DisabledBy = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ReserveId = table.Column<int>(nullable: true),
                    MovementType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlows_Reserves_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReserveItems",
                columns: table => new
                {
                    IdReserveItem = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    DisabledAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    DisabledBy = table.Column<int>(nullable: false),
                    ReserveId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveItems", x => x.IdReserveItem);
                    table.ForeignKey(
                        name: "FK_ReserveItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReserveItems_Reserves_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(100)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(100)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Value = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { 1, "0ce10c37-eba8-462c-a45f-5d3c5f39c1c8", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "DisabledAt", "DisabledBy", "Email", "EmailConfirmed", "LastUpdatedAt", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UserName" },
                values: new object[] { 1, 0, "4109642f-fa45-424d-9f06-cd9ab737dafc", 0, null, 0, "admin@admin.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIYWDjDBjBb1/HwtsQSxPiyJuFK/ZMT3j5CjnGRKAXRVYZ0Jx7Zei5tlp7eyfkWOGg==", null, false, "2213a047-a3f6-4c91-bab0-6642e2693b9f", false, 0, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DisabledAt", "DisabledBy", "LastUpdatedAt", "Name", "Type", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 19, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2147), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2148), "Alterar Reserva", "Reserve", 0, "Edit" },
                    { 20, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2151), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2152), "Desativar Reserva", "Reserve", 0, "Disable" },
                    { 21, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2154), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2155), "Reativar Reserva", "Reserve", 0, "Reactive" },
                    { 22, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2157), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2158), "Listar Itens", "Item", 0, "All" },
                    { 23, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2160), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2161), "Visualizar Item", "Item", 0, "Get" },
                    { 24, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2163), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2165), "Adicionar Item", "Item", 0, "Add" },
                    { 25, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2167), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2168), "Alterar Item", "Item", 0, "Edit" },
                    { 26, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2170), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2171), "Desativar Item", "Item", 0, "Disable" },
                    { 27, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2173), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2174), "Reativar Item", "Item", 0, "Reactive" },
                    { 28, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2176), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2177), "Listar Permissões", "Permission", 0, "All" },
                    { 29, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2179), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2180), "Listar Fluxo de Caixa", "CashFlow", 0, "All" },
                    { 30, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2182), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2183), "Visualizar Fluxo de Caixa", "CashFlow", 0, "Get" },
                    { 31, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2185), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2186), "Adicionar Fluxo de Caixa", "CashFlow", 0, "Add" },
                    { 32, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2188), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2190), "Alterar Fluxo de Caixa", "CashFlow", 0, "Edit" },
                    { 18, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2144), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2145), "Adicionar Reserva", "Reserve", 0, "Add" },
                    { 17, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2140), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2141), "Visualizar Reserva", "Reserve", 0, "Get" },
                    { 16, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2136), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2137), "Listar Reservas", "Reserve", 0, "All" },
                    { 15, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2133), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2134), "Remover Permissão da Função", "Role", 0, "DeleteClaim" },
                    { 1, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(1484), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(1492), "Listar Usuários", "User", 0, "All" },
                    { 2, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2074), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2080), "Visualizar Usuário", "User", 0, "Get" },
                    { 3, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2091), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2092), "Adicionar Usuário", "User", 0, "Add" },
                    { 4, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2095), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2096), "Alterar Usuário", "User", 0, "Edit" },
                    { 5, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2098), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2099), "Desativar Usuário", "User", 0, "Disable" },
                    { 6, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2104), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2105), "Reativar Usuário", "User", 0, "Reactive" },
                    { 33, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2191), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2193), "Desativar Fluxo de Caixa", "CashFlow", 0, "Disable" },
                    { 7, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2107), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2108), "Trocar Senha", "User", 0, "ChangePassword" },
                    { 9, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2113), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2115), "Listar Funções", "Role", 0, "All" },
                    { 10, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2118), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2119), "Visualizar Função", "Role", 0, "Get" },
                    { 11, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2121), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2122), "Adicionar Função", "Role", 0, "Add" },
                    { 12, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2124), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2125), "Alterar Função", "Role", 0, "Edit" },
                    { 13, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2127), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2128), "Apagar Função", "Role", 0, "Delete" },
                    { 14, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2130), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2131), "Adicionar Permissão a Função", "Role", 0, "AddClaim" },
                    { 8, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2110), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2111), "Trocar Senha de outro Usuário", "User", 0, "ChangeUserPassword" },
                    { 34, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2256), 0, null, 0, new DateTime(2020, 10, 24, 22, 51, 40, 871, DateTimeKind.Local).AddTicks(2257), "Reativar Fluxo de Caixa", "CashFlow", 0, "Reactive" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlows_ReserveId",
                table: "CashFlows",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_Type_Value",
                table: "permissions",
                columns: new[] { "Type", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ItemId",
                table: "ReserveItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveItems_ReserveId",
                table: "ReserveItems",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlows");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "ReserveItems");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

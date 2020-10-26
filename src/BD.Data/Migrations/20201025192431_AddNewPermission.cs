using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BD.Data.Migrations
{
    public partial class AddNewPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b9b68ab1-12ca-41e3-ae75-8d81215b4959");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00e5f176-01d4-4357-bb3f-ea7efb0dc4d1", "AQAAAAEAACcQAAAAEKBoCnntZGprfHcBjuZ9bqBK9vn9amUDhMIchTIhHE1OnGlCKlK/v5QXq7O+6V0KLg==", "9b847b25-2e78-432f-8831-82625b38abbe" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(1700), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2325), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2343), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2344) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2348), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2349) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2352), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2359), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2362), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2363) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2365), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2366) });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2368), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2369), "Atualizar Grupos de um Usuário", "User", "UpdateRoles" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2372), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2373), "Listar Funções", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2375), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2376), "Visualizar Função", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2378), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2379), "Adicionar Função", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2381), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2382), "Alterar Função", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2384), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2385), "Apagar Função", "Delete" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2387), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2388), "Adicionar Permissão a Função", "AddClaim" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2390), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2391), "Remover Permissão da Função", "Role", "DeleteClaim" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2393), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2394), "Listar Reservas", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2398), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2399), "Visualizar Reserva", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2401), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2402), "Adicionar Reserva", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2404), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2405), "Alterar Reserva", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2407), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2408), "Desativar Reserva", "Disable" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2410), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2411), "Reativar Reserva", "Reserve", "Reactive" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2413), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2414), "Listar Itens", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2416), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2417), "Visualizar Item", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2419), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2420), "Adicionar Item", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2423), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2424), "Alterar Item", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2426), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2427), "Desativar Item", "Disable" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2429), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2430), "Reativar Item", "Item", "Reactive" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2432), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2433), "Listar Permissões", "Permission" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2435), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2436), "Listar Fluxo de Caixa", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2438), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2439), "Visualizar Fluxo de Caixa", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2441), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2442), "Adicionar Fluxo de Caixa", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2444), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2445), "Alterar Fluxo de Caixa", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2449), new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2450), "Desativar Fluxo de Caixa", "Disable" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DisabledAt", "DisabledBy", "LastUpdatedAt", "Name", "Type", "UpdatedBy", "Value" },
                values: new object[] { 35, new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2545), 0, null, 0, new DateTime(2020, 10, 25, 16, 24, 31, 227, DateTimeKind.Local).AddTicks(2547), "Reativar Fluxo de Caixa", "CashFlow", 0, "Reactive" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 35);

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
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6463), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6465), "Listar Funções", "Role", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6469), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6471), "Visualizar Função", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6474), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6475), "Adicionar Função", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6478), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6480), "Alterar Função", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6482), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6484), "Apagar Função", "Delete" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6489), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6490), "Adicionar Permissão a Função", "AddClaim" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6493), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6495), "Remover Permissão da Função", "DeleteClaim" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6497), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6499), "Listar Reservas", "Reserve", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6501), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6503), "Visualizar Reserva", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6509), "Adicionar Reserva", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6512), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6513), "Alterar Reserva", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6516), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6518), "Desativar Reserva", "Disable" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6520), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6522), "Reativar Reserva", "Reactive" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6524), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6526), "Listar Itens", "Item", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6529), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6530), "Visualizar Item", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6533), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6535), "Adicionar Item", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6537), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6539), "Alterar Item", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6541), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6543), "Desativar Item", "Disable" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6546), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6547), "Reativar Item", "Reactive" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6550), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6551), "Listar Permissões", "Permission", "All" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Type" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6554), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6556), "Listar Fluxo de Caixa", "CashFlow" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6558), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6560), "Visualizar Fluxo de Caixa", "Get" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6562), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6564), "Adicionar Fluxo de Caixa", "Add" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6567), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6568), "Alterar Fluxo de Caixa", "Edit" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6571), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6573), "Desativar Fluxo de Caixa", "Disable" });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Name", "Value" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6577), new DateTime(2020, 10, 24, 23, 23, 3, 74, DateTimeKind.Local).AddTicks(6579), "Reativar Fluxo de Caixa", "Reactive" });
        }
    }
}

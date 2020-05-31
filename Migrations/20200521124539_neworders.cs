using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DutchTreat.Migrations
{
    public partial class neworders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_storeUserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_storeUserId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "storeUserId",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2020, 5, 21, 12, 45, 38, 809, DateTimeKind.Utc).AddTicks(1819));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "storeUserId",
                table: "orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2020, 3, 31, 18, 26, 57, 583, DateTimeKind.Utc).AddTicks(8701));

            migrationBuilder.CreateIndex(
                name: "IX_orders_storeUserId",
                table: "orders",
                column: "storeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_storeUserId",
                table: "orders",
                column: "storeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

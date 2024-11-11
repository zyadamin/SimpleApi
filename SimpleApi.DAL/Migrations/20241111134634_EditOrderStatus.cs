using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApi.DAL.Migrations
{
    public partial class EditOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 15, 46, 33, 918, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 15, 46, 33, 918, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 15, 46, 33, 918, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 15, 46, 33, 918, DateTimeKind.Local).AddTicks(7867));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 17, 19, 28, 264, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 17, 19, 28, 264, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 17, 19, 28, 264, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 17, 19, 28, 264, DateTimeKind.Local).AddTicks(8284));
        }
    }
}

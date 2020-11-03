using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.DataBase.Migrations
{
    public partial class addDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 10, 30, 16, 47, 52, 681, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Complete", "CreateDate", "DeadLine", "EndDate", "Title", "UserDataId" },
                values: new object[,]
                {
                    { 2, false, new DateTime(2020, 10, 30, 16, 47, 52, 684, DateTimeKind.Local).AddTicks(5705), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test2", 1 },
                    { 3, false, new DateTime(2020, 10, 30, 16, 47, 52, 684, DateTimeKind.Local).AddTicks(5748), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test3", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserDatas",
                columns: new[] { "Id", "Desk" },
                values: new object[] { 2, "Tets desk2" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Complete", "CreateDate", "DeadLine", "EndDate", "Title", "UserDataId" },
                values: new object[] { 4, false, new DateTime(2020, 10, 30, 16, 47, 52, 684, DateTimeKind.Local).AddTicks(5754), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test1", 2 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Complete", "CreateDate", "DeadLine", "EndDate", "Title", "UserDataId" },
                values: new object[] { 5, false, new DateTime(2020, 10, 30, 16, 47, 52, 684, DateTimeKind.Local).AddTicks(5760), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test2", 2 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Complete", "CreateDate", "DeadLine", "EndDate", "Title", "UserDataId" },
                values: new object[] { 6, false, new DateTime(2020, 10, 30, 16, 47, 52, 684, DateTimeKind.Local).AddTicks(5766), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test3", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserDatas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 10, 30, 16, 32, 54, 465, DateTimeKind.Local).AddTicks(5930));
        }
    }
}

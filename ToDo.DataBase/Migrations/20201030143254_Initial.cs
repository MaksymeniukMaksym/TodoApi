using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.DataBase.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Complete = table.Column<bool>(nullable: false),
                    UserDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_UserDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserDatas",
                columns: new[] { "Id", "Desk" },
                values: new object[] { 1, "Tets desk" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Complete", "CreateDate", "DeadLine", "EndDate", "Title", "UserDataId" },
                values: new object[] { 1, false, new DateTime(2020, 10, 30, 16, 32, 54, 465, DateTimeKind.Local).AddTicks(5930), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test1", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserDataId",
                table: "Todos",
                column: "UserDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "UserDatas");
        }
    }
}

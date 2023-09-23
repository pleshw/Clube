using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clube.Migrations
{
    /// <inheritdoc />
    public partial class CreatedOnRPGClassesDefaultValueCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 23, 7, 57, 57, 652, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 23, 7, 57, 57, 652, DateTimeKind.Local).AddTicks(8238));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 23, 7, 57, 57, 652, DateTimeKind.Local).AddTicks(7900),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 23, 7, 57, 57, 652, DateTimeKind.Local).AddTicks(8238),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "getdate()");
        }
    }
}

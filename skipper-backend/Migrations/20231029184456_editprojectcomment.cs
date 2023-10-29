using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class editprojectcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79446a3e-364f-4689-a855-1361ed526aba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b62ff46b-6086-4213-8c66-35cbb80804ad");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ProjectComment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f651bf7-fc36-42a5-ae23-e9a09de3279d", null, "Admin", "ADMIN" },
                    { "cfc78945-56c7-4ac1-b393-d573fd14eb9d", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f651bf7-fc36-42a5-ae23-e9a09de3279d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfc78945-56c7-4ac1-b393-d573fd14eb9d");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ProjectComment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79446a3e-364f-4689-a855-1361ed526aba", null, "Admin", "ADMIN" },
                    { "b62ff46b-6086-4213-8c66-35cbb80804ad", null, "Member", "MEMBER" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class editprojectlead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa9b7543-c922-42f6-b328-ca9d543a6b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f28973a7-08bd-461a-b610-c1fe00a6fc0d");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ProjectLead",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79446a3e-364f-4689-a855-1361ed526aba", null, "Admin", "ADMIN" },
                    { "b62ff46b-6086-4213-8c66-35cbb80804ad", null, "Member", "MEMBER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLead_ProjectId",
                table: "ProjectLead",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLead_CompanyProject_ProjectId",
                table: "ProjectLead",
                column: "ProjectId",
                principalTable: "CompanyProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLead_CompanyProject_ProjectId",
                table: "ProjectLead");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLead_ProjectId",
                table: "ProjectLead");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79446a3e-364f-4689-a855-1361ed526aba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b62ff46b-6086-4213-8c66-35cbb80804ad");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectLead");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa9b7543-c922-42f6-b328-ca9d543a6b0e", null, "Admin", "ADMIN" },
                    { "f28973a7-08bd-461a-b610-c1fe00a6fc0d", null, "Member", "MEMBER" }
                });
        }
    }
}

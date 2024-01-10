using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class editskillsm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsMatrixSingleSkillInput_SkillsMatrixInput_SkillsMatrixInputId",
                table: "SkillsMatrixSingleSkillInput");

            migrationBuilder.RenameColumn(
                name: "SkillsMatrixInputId",
                table: "SkillsMatrixSingleSkillInput",
                newName: "SkillsMatrixInputID");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsMatrixSingleSkillInput_SkillsMatrixInputId",
                table: "SkillsMatrixSingleSkillInput",
                newName: "IX_SkillsMatrixSingleSkillInput_SkillsMatrixInputID");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillsMatrixInputID",
                table: "SkillsMatrixSingleSkillInput",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_SkillsMatrixSingleSkillInput_SkillsMatrixInput_SkillsMatrixInputID",
                table: "SkillsMatrixSingleSkillInput",
                column: "SkillsMatrixInputID",
                principalTable: "SkillsMatrixInput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsMatrixSingleSkillInput_SkillsMatrixInput_SkillsMatrixInputID",
                table: "SkillsMatrixSingleSkillInput");

            migrationBuilder.RenameColumn(
                name: "SkillsMatrixInputID",
                table: "SkillsMatrixSingleSkillInput",
                newName: "SkillsMatrixInputId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsMatrixSingleSkillInput_SkillsMatrixInputID",
                table: "SkillsMatrixSingleSkillInput",
                newName: "IX_SkillsMatrixSingleSkillInput_SkillsMatrixInputId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillsMatrixInputId",
                table: "SkillsMatrixSingleSkillInput",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsMatrixSingleSkillInput_SkillsMatrixInput_SkillsMatrixInputId",
                table: "SkillsMatrixSingleSkillInput",
                column: "SkillsMatrixInputId",
                principalTable: "SkillsMatrixInput",
                principalColumn: "Id");
        }
    }
}

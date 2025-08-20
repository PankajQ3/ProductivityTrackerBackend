using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductivityTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class modifyrRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Items",
                newName: "GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_UserId",
                table: "Items",
                newName: "IX_Items_GoalId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Goals_GoalId",
                table: "Items",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Goals_GoalId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Items",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_GoalId",
                table: "Items",
                newName: "IX_Items_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

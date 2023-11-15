using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDishesDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restautrants_RestautrantId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RestautrantId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "RestautrantId",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "DishEncodedName",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantID",
                table: "Dishes",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restautrants_RestaurantID",
                table: "Dishes",
                column: "RestaurantID",
                principalTable: "Restautrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restautrants_RestaurantID",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RestaurantID",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishEncodedName",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "RestautrantId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestautrantId",
                table: "Dishes",
                column: "RestautrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restautrants_RestautrantId",
                table: "Dishes",
                column: "RestautrantId",
                principalTable: "Restautrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restautrants_RestaurantID",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restautrants_RestaurantID",
                table: "Dishes",
                column: "RestaurantID",
                principalTable: "Restautrants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restautrants_RestaurantID",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restautrants_RestaurantID",
                table: "Dishes",
                column: "RestaurantID",
                principalTable: "Restautrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

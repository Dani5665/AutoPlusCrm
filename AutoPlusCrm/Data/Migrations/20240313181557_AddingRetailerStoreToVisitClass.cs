using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRetailerStoreToVisitClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetailerStoreId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RetailerStoreId",
                table: "Tasks",
                column: "RetailerStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RetailerStores_RetailerStoreId",
                table: "Tasks",
                column: "RetailerStoreId",
                principalTable: "RetailerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RetailerStores_RetailerStoreId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RetailerStoreId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RetailerStoreId",
                table: "Tasks");
        }
    }
}

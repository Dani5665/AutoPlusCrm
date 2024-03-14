using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingRelationsInApplicationUserToRetailerStores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStore",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserStoreId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserStoreId",
                table: "AspNetUsers",
                column: "UserStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RetailerStores_UserStoreId",
                table: "AspNetUsers",
                column: "UserStoreId",
                principalTable: "RetailerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RetailerStores_UserStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserStoreId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserStore",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRetailerStoreToClientClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetailerStoresId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RetailerStoresId",
                table: "Clients",
                column: "RetailerStoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_RetailerStores_RetailerStoresId",
                table: "Clients",
                column: "RetailerStoresId",
                principalTable: "RetailerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_RetailerStores_RetailerStoresId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_RetailerStoresId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RetailerStoresId",
                table: "Clients");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelationToClientCurrentCreditLimit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreditLimitId",
                table: "Clients",
                column: "CreditLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MainDiscountId",
                table: "Clients",
                column: "MainDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_CreditLimits_CreditLimitId",
                table: "Clients",
                column: "CreditLimitId",
                principalTable: "CreditLimits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MainDiscounts_MainDiscountId",
                table: "Clients",
                column: "MainDiscountId",
                principalTable: "MainDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_CreditLimits_CreditLimitId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MainDiscounts_MainDiscountId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreditLimitId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MainDiscountId",
                table: "Clients");
        }
    }
}

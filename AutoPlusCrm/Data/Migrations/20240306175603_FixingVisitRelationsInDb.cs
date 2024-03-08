using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingVisitRelationsInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTypes_Visits_VisitId1",
                table: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_VisitGrades_VisitClassId",
                table: "VisitGrades");

            migrationBuilder.DropIndex(
                name: "IX_ClientTypes_VisitId1",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "SupplierStore",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitCreator",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitGradeId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitId1",
                table: "ClientTypes");

            migrationBuilder.AddColumn<int>(
                name: "RetailerStoreId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RetailerStoresId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitCreatorId",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ClientTypeId",
                table: "Visits",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_RetailerStoreId",
                table: "Visits",
                column: "RetailerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_RetailerStoresId",
                table: "Visits",
                column: "RetailerStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitCreatorId",
                table: "Visits",
                column: "VisitCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitGrades_VisitClassId",
                table: "VisitGrades",
                column: "VisitClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_VisitCreatorId",
                table: "Visits",
                column: "VisitCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_ClientTypes_ClientTypeId",
                table: "Visits",
                column: "ClientTypeId",
                principalTable: "ClientTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_RetailerStores_RetailerStoreId",
                table: "Visits",
                column: "RetailerStoreId",
                principalTable: "RetailerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_RetailerStores_RetailerStoresId",
                table: "Visits",
                column: "RetailerStoresId",
                principalTable: "RetailerStores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_VisitCreatorId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_ClientTypes_ClientTypeId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_RetailerStores_RetailerStoreId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_RetailerStores_RetailerStoresId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_ClientTypeId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_RetailerStoreId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_RetailerStoresId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitCreatorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_VisitGrades_VisitClassId",
                table: "VisitGrades");

            migrationBuilder.DropColumn(
                name: "RetailerStoreId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "RetailerStoresId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitCreatorId",
                table: "Visits");

            migrationBuilder.AddColumn<string>(
                name: "SupplierStore",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "The name of the supplier store");

            migrationBuilder.AddColumn<string>(
                name: "VisitCreator",
                table: "Visits",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "The name of the user that created the task");

            migrationBuilder.AddColumn<string>(
                name: "VisitGradeId",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VisitId1",
                table: "ClientTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Id of the visit");

            migrationBuilder.CreateIndex(
                name: "IX_VisitGrades_VisitClassId",
                table: "VisitGrades",
                column: "VisitClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_VisitId1",
                table: "ClientTypes",
                column: "VisitId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTypes_Visits_VisitId1",
                table: "ClientTypes",
                column: "VisitId1",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

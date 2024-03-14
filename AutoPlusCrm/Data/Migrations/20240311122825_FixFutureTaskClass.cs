using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixFutureTaskClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskCreator",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TaskDescription",
                table: "Tasks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Description of the task");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ApplicationUserId",
                table: "Tasks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ClientId",
                table: "Tasks",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_ApplicationUserId",
                table: "Tasks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Clients_ClientId",
                table: "Tasks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_ApplicationUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Clients_ClientId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ApplicationUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ClientId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskDescription",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Tasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "The name of the client that will be visited");

            migrationBuilder.AddColumn<string>(
                name: "TaskCreator",
                table: "Tasks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "The name of the user that created the task");
        }
    }
}

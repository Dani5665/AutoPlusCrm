using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientTypeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The type of the client (Store, Service...)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the client that will be visited"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date when the visit will be made"),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The city in which the client store is located"),
                    Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The region in which the client store is located"),
                    TaskCreator = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The name of the user that created the task")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitGradeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "A grade of the visit (Positive/Neutral/Negative)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitGradeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the client"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "City where the client is registered"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Address of client"),
                    Bulstat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Firm bulstat"),
                    AccountablePerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the accountable person (MOL)"),
                    PersonToContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Person to contact"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Client phone number"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Client email address"),
                    CatalogueUser = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Username for the catalogue"),
                    CataloguePassword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Password for the catalogue"),
                    SkypeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Skype username"),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Website url"),
                    MainDiscountModelId = table.Column<int>(type: "int", nullable: false),
                    CreditLimitModelId = table.Column<int>(type: "int", nullable: false),
                    DelayedPaymentPeriod = table.Column<int>(type: "int", nullable: false, comment: "Delayed payment period in days"),
                    ClientDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Short description about the client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditLimitModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditLimit = table.Column<int>(type: "int", nullable: false, comment: "Number of the credit limit"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the credit limit was created"),
                    ClientModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditLimitModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditLimitModels_ClientModels_ClientModelId",
                        column: x => x.ClientModelId,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainDiscountModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false, comment: "Number of the discount in percentage"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the discount was created"),
                    ClientModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDiscountModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainDiscountModels_ClientModels_ClientModelId",
                        column: x => x.ClientModelId,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the store"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The address of the store"),
                    NumberOfWorkers = table.Column<int>(type: "int", maxLength: 5, nullable: false, comment: "The number of workers in the store"),
                    NumberOfMechanics = table.Column<int>(type: "int", maxLength: 5, nullable: false, comment: "The number of mechanics in the store"),
                    NumberOfVehicles = table.Column<int>(type: "int", maxLength: 5, nullable: false, comment: "The number of vehicles in the store"),
                    PersonToContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the person to contact"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The phone number of the person to contact"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The email of the person to contact"),
                    CatalogueUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Username for AP catalogue"),
                    CataloguePassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Password for AP catalogue"),
                    ClientModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreModels_ClientModels_ClientModelId",
                        column: x => x.ClientModelId,
                        principalTable: "ClientModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitPurpose = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Purpose of the visit"),
                    CustomerComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Any information that came from the client. It can be about our products, competitors, his impressions..."),
                    TakenActions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Actions taken from the visitor so that the client starts using our services and products "),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date when the visit happened"),
                    VisitGradelId = table.Column<int>(type: "int", nullable: false),
                    VisitCreator = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The name of the user that created the task"),
                    StoreModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitModels_StoreModels_StoreModelId",
                        column: x => x.StoreModelId,
                        principalTable: "StoreModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitModels_VisitGradeModels_VisitGradelId",
                        column: x => x.VisitGradelId,
                        principalTable: "VisitGradeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientModels_CreditLimitModelId",
                table: "ClientModels",
                column: "CreditLimitModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientModels_MainDiscountModelId",
                table: "ClientModels",
                column: "MainDiscountModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditLimitModels_ClientModelId",
                table: "CreditLimitModels",
                column: "ClientModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MainDiscountModels_ClientModelId",
                table: "MainDiscountModels",
                column: "ClientModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreModels_ClientModelId",
                table: "StoreModels",
                column: "ClientModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitModels_StoreModelId",
                table: "VisitModels",
                column: "StoreModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitModels_VisitGradelId",
                table: "VisitModels",
                column: "VisitGradelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientModels_CreditLimitModels_CreditLimitModelId",
                table: "ClientModels",
                column: "CreditLimitModelId",
                principalTable: "CreditLimitModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientModels_MainDiscountModels_MainDiscountModelId",
                table: "ClientModels",
                column: "MainDiscountModelId",
                principalTable: "MainDiscountModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientModels_CreditLimitModels_CreditLimitModelId",
                table: "ClientModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientModels_MainDiscountModels_MainDiscountModelId",
                table: "ClientModels");

            migrationBuilder.DropTable(
                name: "ClientTypeModels");

            migrationBuilder.DropTable(
                name: "TaskModels");

            migrationBuilder.DropTable(
                name: "VisitModels");

            migrationBuilder.DropTable(
                name: "StoreModels");

            migrationBuilder.DropTable(
                name: "VisitGradeModels");

            migrationBuilder.DropTable(
                name: "CreditLimitModels");

            migrationBuilder.DropTable(
                name: "MainDiscountModels");

            migrationBuilder.DropTable(
                name: "ClientModels");
        }
    }
}

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
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the client"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "City where the client is registered"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Address of client"),
                    Bulstat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Firm bulstat"),
                    AccountablePerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name of the accountable person (MOL)"),
                    PersonToContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Person to contact"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Client phone number"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Client email address"),
                    CatalogueUser = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Username for the catalogue"),
                    CataloguePassword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Password for the catalogue"),
                    SkypeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Skype username"),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Website url"),
                    MainDiscountId = table.Column<int>(type: "int", nullable: false),
                    CreditLimitId = table.Column<int>(type: "int", nullable: false),
                    DelayedPaymentPeriod = table.Column<int>(type: "int", nullable: true, comment: "Delayed payment period in days"),
                    ClientDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Short description about the client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The type of the client (Store, Service...)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
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
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "A grade of the visit (Positive/Neutral/Negative)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false, comment: "Number of the credit limit"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the credit limit was created"),
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Id of the client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditLimits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false, comment: "Number of the discount in percentage"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the discount was created"),
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Id of the client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainDiscounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the store"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "The address of the store"),
                    NumberOfWorkers = table.Column<int>(type: "int", maxLength: 5, nullable: true, comment: "The number of workers in the store"),
                    NumberOfMechanics = table.Column<int>(type: "int", maxLength: 5, nullable: true, comment: "The number of mechanics in the store"),
                    NumberOfVehicles = table.Column<int>(type: "int", maxLength: 5, nullable: true, comment: "The number of vehicles in the store"),
                    PersonToContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The name of the person to contact"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "The phone number of the person to contact"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The email of the person to contact"),
                    CatalogueUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Username for AP catalogue"),
                    CataloguePassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Password for AP catalogue"),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visits",
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
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Id of the client"),
                    ClientStoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Stores_ClientStoreId",
                        column: x => x.ClientStoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visits_VisitGrades_VisitGradelId",
                        column: x => x.VisitGradelId,
                        principalTable: "VisitGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditLimits_ClientId",
                table: "CreditLimits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MainDiscounts_ClientId",
                table: "MainDiscounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ClientId",
                table: "Stores",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ClientStoreId",
                table: "Visits",
                column: "ClientStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitGradelId",
                table: "Visits",
                column: "VisitGradelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "CreditLimits");

            migrationBuilder.DropTable(
                name: "MainDiscounts");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "VisitGrades");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

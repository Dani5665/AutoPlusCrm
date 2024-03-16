using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPlusCrm.Data.Migrations
{
    /// <inheritdoc />
    public partial class RevertFixingDateFormats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfVisit",
                table: "Visits",
                type: "datetime2",
                nullable: false,
                comment: "The date when the visit happened",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The date when the visit happened");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                comment: "The date when the visit will be made",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The date when the visit will be made");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "MainDiscounts",
                type: "datetime2",
                nullable: false,
                comment: "Date and time when the discount was created",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Date and time when the discount was created");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "CreditLimits",
                type: "datetime2",
                nullable: false,
                comment: "Date and time when the credit limit was created",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Date and time when the credit limit was created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfVisit",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The date when the visit happened",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The date when the visit happened");

            migrationBuilder.AlterColumn<string>(
                name: "DateAndTime",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The date when the visit will be made",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The date when the visit will be made");

            migrationBuilder.AlterColumn<string>(
                name: "DateAndTime",
                table: "MainDiscounts",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Date and time when the discount was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when the discount was created");

            migrationBuilder.AlterColumn<string>(
                name: "DateAndTime",
                table: "CreditLimits",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Date and time when the credit limit was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when the credit limit was created");
        }
    }
}

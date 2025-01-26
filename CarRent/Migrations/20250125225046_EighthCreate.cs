using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    /// <inheritdoc />
    public partial class EighthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_1_Service_ServiceId",
                table: "Incident_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incident_1",
                table: "Incident_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount_1",
                table: "Discount_1");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Discount_1");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Discount_1");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Incident_1",
                newName: "Incident");

            migrationBuilder.RenameTable(
                name: "Discount_1",
                newName: "Discounts");

            migrationBuilder.RenameIndex(
                name: "IX_Incident_1_ServiceId",
                table: "Incident",
                newName: "IX_Incident_ServiceId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Discounts",
                newName: "DiscountCode");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Discounts",
                newName: "DiscountAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercentage",
                table: "Discounts",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incident",
                table: "Incident",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Services_ServiceId",
                table: "Incident",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Services_ServiceId",
                table: "Incident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incident",
                table: "Incident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountDate",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Discounts");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Incident",
                newName: "Incident_1");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount_1");

            migrationBuilder.RenameIndex(
                name: "IX_Incident_ServiceId",
                table: "Incident_1",
                newName: "IX_Incident_1_ServiceId");

            migrationBuilder.RenameColumn(
                name: "DiscountCode",
                table: "Discount_1",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Discount_1",
                newName: "Amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Discount_1",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Discount_1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incident_1",
                table: "Incident_1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount_1",
                table: "Discount_1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_1_Service_ServiceId",
                table: "Incident_1",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

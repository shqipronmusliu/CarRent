using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    /// <inheritdoc />
    public partial class FifthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ResolutionPrice",
                table: "Incident");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Incident",
                newName: "Incident_1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Incident_1",
                newName: "ReportedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Incident_ServiceId",
                table: "Incident_1",
                newName: "IX_Incident_1_ServiceId");

            migrationBuilder.AddColumn<string>(
                name: "ResolvedBy",
                table: "Incident_1",
                type: "nvarchar(max)",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_1_Service_ServiceId",
                table: "Incident_1",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ResolvedBy",
                table: "Incident_1");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Incident_1",
                newName: "Incident");

            migrationBuilder.RenameColumn(
                name: "ReportedBy",
                table: "Incident",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Incident_1_ServiceId",
                table: "Incident",
                newName: "IX_Incident_ServiceId");

            migrationBuilder.AddColumn<decimal>(
                name: "ResolutionPrice",
                table: "Incident",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incident",
                table: "Incident",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Services_ServiceId",
                table: "Incident",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

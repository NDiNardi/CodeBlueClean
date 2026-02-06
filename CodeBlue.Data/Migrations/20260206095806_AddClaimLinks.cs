using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBlue.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClaimLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyClaims_Customers_CustomerId",
                table: "WarrantyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyClaims_WorkOrders_WorkOrderId",
                table: "WarrantyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AddressSnapshot",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AssignedTechnicianUserId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContactFirstName",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContactLastName",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderPhone",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CompletedUtc",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "SubmittedUtc",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CompletedByUserId",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "CompletedUtc",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "WarrantyClaims");

            migrationBuilder.RenameColumn(
                name: "SystemStartupDate",
                table: "WorkOrders",
                newName: "ServiceStartupDate");

            migrationBuilder.RenameColumn(
                name: "ServiceContactPhone",
                table: "WorkOrders",
                newName: "ServiceZip");

            migrationBuilder.RenameColumn(
                name: "ServiceContactLastName",
                table: "WorkOrders",
                newName: "ServiceStreet1");

            migrationBuilder.RenameColumn(
                name: "ServiceContactFirstName",
                table: "WorkOrders",
                newName: "ServiceState");

            migrationBuilder.RenameColumn(
                name: "ProblemDescription",
                table: "WorkOrders",
                newName: "ServiceCity");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "WorkOrders",
                newName: "Space");

            migrationBuilder.RenameColumn(
                name: "GateCodeSnapshot",
                table: "WorkOrders",
                newName: "ServiceAddress");

            migrationBuilder.RenameColumn(
                name: "AnimalsPresentSnapshot",
                table: "WorkOrders",
                newName: "AnimalsPresent");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "WarrantyClaims",
                newName: "Street2");

            migrationBuilder.RenameColumn(
                name: "SerialImage2Path",
                table: "WarrantyClaims",
                newName: "ServiceRequest");

            migrationBuilder.RenameColumn(
                name: "SerialImage1Path",
                table: "WarrantyClaims",
                newName: "OriginalInstallerDealer");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "WarrantyClaims",
                newName: "Zip");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "WorkOrders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BuilderCompanyName",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AddressKey",
                table: "WorkOrders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderContact",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderContactFirst",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderContactLast",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderContactMiddle",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderContactTitle",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderPhoneNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompletedBy",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GateCode",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegacyRecordId",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreKey",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContact",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContactFirst",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContactLast",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContactMiddle",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContactTitle",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceCountry",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceDetails",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceLatitude",
                table: "WorkOrders",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceLongitude",
                table: "WorkOrders",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicePhone",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceStreet2",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkOrderId",
                table: "WarrantyClaims",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "WarrantyClaims",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimNumber",
                table: "WarrantyClaims",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressKey",
                table: "WarrantyClaims",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompletedBy",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComponentSerialNumber",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdSerialNumber",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1Url",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2Url",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "WarrantyClaims",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegacyRecordId",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "WarrantyClaims",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "OriginalInstallationDate",
                table: "WarrantyClaims",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street1",
                table: "WarrantyClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyClaims_Customers_CustomerId",
                table: "WarrantyClaims",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyClaims_WorkOrders_WorkOrderId",
                table: "WarrantyClaims",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyClaims_Customers_CustomerId",
                table: "WarrantyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyClaims_WorkOrders_WorkOrderId",
                table: "WarrantyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AddressKey",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContact",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContactFirst",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContactLast",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContactMiddle",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderContactTitle",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuilderPhoneNumber",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CompletedBy",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "GateCode",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "LegacyRecordId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "PreKey",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceContact",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceContactFirst",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceContactLast",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceContactMiddle",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceContactTitle",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceCountry",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceDetails",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceLatitude",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceLongitude",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServicePhone",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ServiceStreet2",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "AddressKey",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "City",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "CompletedBy",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "ComponentSerialNumber",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "IdSerialNumber",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Image1Url",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Image2Url",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "LegacyRecordId",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "OriginalInstallationDate",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "State",
                table: "WarrantyClaims");

            migrationBuilder.DropColumn(
                name: "Street1",
                table: "WarrantyClaims");

            migrationBuilder.RenameColumn(
                name: "Space",
                table: "WorkOrders",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "ServiceZip",
                table: "WorkOrders",
                newName: "ServiceContactPhone");

            migrationBuilder.RenameColumn(
                name: "ServiceStreet1",
                table: "WorkOrders",
                newName: "ServiceContactLastName");

            migrationBuilder.RenameColumn(
                name: "ServiceState",
                table: "WorkOrders",
                newName: "ServiceContactFirstName");

            migrationBuilder.RenameColumn(
                name: "ServiceStartupDate",
                table: "WorkOrders",
                newName: "SystemStartupDate");

            migrationBuilder.RenameColumn(
                name: "ServiceCity",
                table: "WorkOrders",
                newName: "ProblemDescription");

            migrationBuilder.RenameColumn(
                name: "ServiceAddress",
                table: "WorkOrders",
                newName: "GateCodeSnapshot");

            migrationBuilder.RenameColumn(
                name: "AnimalsPresent",
                table: "WorkOrders",
                newName: "AnimalsPresentSnapshot");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "WarrantyClaims",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Street2",
                table: "WarrantyClaims",
                newName: "SerialNumber");

            migrationBuilder.RenameColumn(
                name: "ServiceRequest",
                table: "WarrantyClaims",
                newName: "SerialImage2Path");

            migrationBuilder.RenameColumn(
                name: "OriginalInstallerDealer",
                table: "WarrantyClaims",
                newName: "SerialImage1Path");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "WorkOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuilderCompanyName",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressSnapshot",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AssignedTechnicianUserId",
                table: "WorkOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuilderContactFirstName",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuilderContactLastName",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuilderPhone",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedUtc",
                table: "WorkOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedUtc",
                table: "WorkOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkOrderId",
                table: "WarrantyClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "WarrantyClaims",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "WarrantyClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimNumber",
                table: "WarrantyClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AddColumn<int>(
                name: "CompletedByUserId",
                table: "WarrantyClaims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedUtc",
                table: "WarrantyClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "WarrantyClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyClaims_Customers_CustomerId",
                table: "WarrantyClaims",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyClaims_WorkOrders_WorkOrderId",
                table: "WarrantyClaims",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

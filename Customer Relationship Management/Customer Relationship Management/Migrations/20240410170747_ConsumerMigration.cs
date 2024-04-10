using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer_Relationship_Management.Migrations
{
    /// <inheritdoc />
    public partial class ConsumerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Leads_LeadId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Leads_LeadId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_LeadId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LeadId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LeadId1",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContractId",
                table: "Leads",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "FirstName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBlock",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Leads_SaleId",
                table: "Leads",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Leads_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Sales_SaleId",
                table: "Leads",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Users_SaleId",
                table: "Leads",
                column: "SaleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Leads_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Sales_SaleId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Users_SaleId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_SaleId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Leads",
                newName: "ContractId");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBlock",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId1",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_LeadId1",
                table: "Sales",
                column: "LeadId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LeadId",
                table: "Contacts",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Leads_LeadId",
                table: "Contacts",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Leads_LeadId1",
                table: "Sales",
                column: "LeadId1",
                principalTable: "Leads",
                principalColumn: "Id");
        }
    }
}

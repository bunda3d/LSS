using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LSS.Server.Migrations
{
    public partial class ProductDTOs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnClearanceFlag",
                table: "Products",
                newName: "IsTrending");

            migrationBuilder.RenameColumn(
                name: "IsMarkedDownFlag",
                table: "Products",
                newName: "IsOnSale");

            migrationBuilder.RenameColumn(
                name: "DaysToManufacture",
                table: "Products",
                newName: "SaleLengthInDays");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewRelease",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnClearance",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QtyInStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtyOrderedOnPO",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesEventStartDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCostOnPO",
                table: "Products",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNewRelease",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsOnClearance",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QtyInStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QtyOrderedOnPO",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesEventStartDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitCostOnPO",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SaleLengthInDays",
                table: "Products",
                newName: "DaysToManufacture");

            migrationBuilder.RenameColumn(
                name: "IsTrending",
                table: "Products",
                newName: "OnClearanceFlag");

            migrationBuilder.RenameColumn(
                name: "IsOnSale",
                table: "Products",
                newName: "IsMarkedDownFlag");
        }
    }
}

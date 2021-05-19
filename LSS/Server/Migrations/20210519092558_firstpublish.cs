using Microsoft.EntityFrameworkCore.Migrations;

namespace LSS.Server.Migrations
{
    public partial class firstpublish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceUnformatted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TemperatureC",
                table: "About");

            migrationBuilder.RenameColumn(
                name: "SizeTypeId",
                table: "SizeUnits",
                newName: "SizeTypeCode");

            migrationBuilder.RenameColumn(
                name: "SizeMeasureId",
                table: "SizeUnits",
                newName: "SizeMeasureCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeTypeCode",
                table: "SizeUnits",
                newName: "SizeTypeId");

            migrationBuilder.RenameColumn(
                name: "SizeMeasureCode",
                table: "SizeUnits",
                newName: "SizeMeasureId");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceUnformatted",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureC",
                table: "About",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

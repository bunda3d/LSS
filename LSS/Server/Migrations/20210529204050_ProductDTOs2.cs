using Microsoft.EntityFrameworkCore.Migrations;

namespace LSS.Server.Migrations
{
    public partial class ProductDTOs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductValueAddJob",
                table: "ProductsPeople",
                newName: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ProductsPeople",
                type: "varchar(120)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ValueAddJob",
                table: "ProductsPeople",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Products",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueAddJob",
                table: "ProductsPeople");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ProductsPeople",
                newName: "ProductValueAddJob");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "ProductsPeople",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)");

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Products",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }
    }
}

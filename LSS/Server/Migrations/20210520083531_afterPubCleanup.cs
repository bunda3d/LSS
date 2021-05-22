using Microsoft.EntityFrameworkCore.Migrations;

namespace LSS.Server.Migrations
{
    public partial class afterPubCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarRatingsPeople_StarRatings_StarRatingId",
                table: "StarRatingsPeople");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsCategories",
                table: "ProductsCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories");

            migrationBuilder.RenameColumn(
                name: "StarRatingId",
                table: "StarRatingsPeople",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StarRatingsPeople_StarRatingId",
                table: "StarRatingsPeople",
                newName: "IX_StarRatingsPeople_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "StarRatingsProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DaysToManufacture",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsCategories",
                table: "ProductsCategories",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.CreateTable(
                name: "PersonProduct",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProduct", x => new { x.PeopleId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PersonProduct_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsPeople",
                columns: table => new
                {
                    StarRatingId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsPeople", x => new { x.PersonId, x.StarRatingId });
                    table.ForeignKey(
                        name: "FK_ProductsPeople_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsPeople_StarRatings_StarRatingId",
                        column: x => x.StarRatingId,
                        principalTable: "StarRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StarRatingsProducts_PersonId",
                table: "StarRatingsProducts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_ProductId",
                table: "ProductsCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProduct_ProductsId",
                table: "PersonProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPeople_StarRatingId",
                table: "ProductsPeople",
                column: "StarRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_StarRatingsPeople_Products_ProductId",
                table: "StarRatingsPeople",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StarRatingsProducts_People_PersonId",
                table: "StarRatingsProducts",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarRatingsPeople_Products_ProductId",
                table: "StarRatingsPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_StarRatingsProducts_People_PersonId",
                table: "StarRatingsProducts");

            migrationBuilder.DropTable(
                name: "PersonProduct");

            migrationBuilder.DropTable(
                name: "ProductsPeople");

            migrationBuilder.DropIndex(
                name: "IX_StarRatingsProducts_PersonId",
                table: "StarRatingsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsCategories",
                table: "ProductsCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductsCategories_ProductId",
                table: "ProductsCategories");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "StarRatingsProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "StarRatingsPeople",
                newName: "StarRatingId");

            migrationBuilder.RenameIndex(
                name: "IX_StarRatingsPeople_ProductId",
                table: "StarRatingsPeople",
                newName: "IX_StarRatingsPeople_StarRatingId");

            migrationBuilder.AlterColumn<int>(
                name: "DaysToManufacture",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsCategories",
                table: "ProductsCategories",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleAssociatedWith = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleIsTrendingFlag = table.Column<bool>(type: "bit", nullable: false),
                    StyleIsTrendingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleSimilarTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StarRatingsPeople_StarRatings_StarRatingId",
                table: "StarRatingsPeople",
                column: "StarRatingId",
                principalTable: "StarRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

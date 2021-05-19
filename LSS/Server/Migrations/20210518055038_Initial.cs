using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LSS.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpYrsOfService = table.Column<int>(type: "int", nullable: false),
                    EmpImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorHexCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorHsvCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorPantoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorDyeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasUsedInProductionFlag = table.Column<bool>(type: "bit", nullable: false),
                    ColorUsedInProductId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatternStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternStyleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeMeasureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasUsedInProductionFlag = table.Column<bool>(type: "bit", nullable: false),
                    PatternUsedInProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatternUsedInPoId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    PriceUnformatted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsMarkedDownFlag = table.Column<bool>(type: "bit", nullable: false),
                    OnClearanceFlag = table.Column<bool>(type: "bit", nullable: false),
                    DaysToManufacture = table.Column<int>(type: "int", nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    PatternId = table.Column<int>(type: "int", nullable: true),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    StarRatingId = table.Column<int>(type: "int", nullable: true),
                    SizeMeasureId = table.Column<int>(type: "int", nullable: true),
                    SizeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeMeasureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarRatingScoreEvent = table.Column<int>(type: "int", precision: 1, nullable: false),
                    StarRatingScoreAvg = table.Column<decimal>(type: "decimal(1,1)", precision: 1, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleSimilarTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleAssociatedWith = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleIsTrendingFlag = table.Column<bool>(type: "bit", nullable: false),
                    StyleIsTrendingReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonStarRating",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    StarRatingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStarRating", x => new { x.PeopleId, x.StarRatingsId });
                    table.ForeignKey(
                        name: "FK_PersonStarRating_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonStarRating_StarRatings_StarRatingsId",
                        column: x => x.StarRatingsId,
                        principalTable: "StarRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStarRating",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    StarRatingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStarRating", x => new { x.ProductsId, x.StarRatingsId });
                    table.ForeignKey(
                        name: "FK_ProductStarRating_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStarRating_StarRatings_StarRatingsId",
                        column: x => x.StarRatingsId,
                        principalTable: "StarRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarRatingsPeople",
                columns: table => new
                {
                    StarRatingId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRatingsPeople", x => new { x.PersonId, x.StarRatingId });
                    table.ForeignKey(
                        name: "FK_StarRatingsPeople_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarRatingsPeople_StarRatings_StarRatingId",
                        column: x => x.StarRatingId,
                        principalTable: "StarRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarRatingsProducts",
                columns: table => new
                {
                    StarRatingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRatingsProducts", x => new { x.ProductId, x.StarRatingId });
                    table.ForeignKey(
                        name: "FK_StarRatingsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarRatingsProducts_StarRatings_StarRatingId",
                        column: x => x.StarRatingId,
                        principalTable: "StarRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonStarRating_StarRatingsId",
                table: "PersonStarRating",
                column: "StarRatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStarRating_StarRatingsId",
                table: "ProductStarRating",
                column: "StarRatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_StarRatingsPeople_StarRatingId",
                table: "StarRatingsPeople",
                column: "StarRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_StarRatingsProducts_StarRatingId",
                table: "StarRatingsProducts",
                column: "StarRatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PatternStyles");

            migrationBuilder.DropTable(
                name: "PersonStarRating");

            migrationBuilder.DropTable(
                name: "ProductsCategories");

            migrationBuilder.DropTable(
                name: "ProductStarRating");

            migrationBuilder.DropTable(
                name: "SizeUnits");

            migrationBuilder.DropTable(
                name: "StarRatingsPeople");

            migrationBuilder.DropTable(
                name: "StarRatingsProducts");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StarRatings");
        }
    }
}

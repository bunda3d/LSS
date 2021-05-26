using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LSS.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //migrationBuilder.CreateTable(
          //    name: "About",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      EmpName = table.Column<string>(type: "varchar(100)", nullable: true),
          //      EmpTitle = table.Column<string>(type: "varchar(100)", nullable: true),
          //      EmpYrsOfService = table.Column<int>(type: "int", nullable: false),
          //      EmpImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
          //      Date = table.Column<DateTime>(type: "datetime2", nullable: false),
          //      Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_About", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "Categories",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      Name = table.Column<string>(type: "varchar(30)", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_Categories", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "Colors",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      ColorName = table.Column<string>(type: "varchar(30)", nullable: true),
          //      ColorHexCode = table.Column<string>(type: "varchar(30)", nullable: true),
          //      ColorHsvCode = table.Column<string>(type: "varchar(30)", nullable: true),
          //      ColorPantoneCode = table.Column<string>(type: "varchar(30)", nullable: true),
          //      ColorDyeName = table.Column<string>(type: "varchar(30)", nullable: true),
          //      WasUsedInProductionFlag = table.Column<bool>(type: "bit", nullable: false),
          //      ColorUsedInProductId = table.Column<int>(type: "int", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_Colors", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "PatternStyles",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      PatternStyleName = table.Column<string>(type: "varchar(30)", nullable: false),
          //      WasUsedInProductionFlag = table.Column<bool>(type: "bit", nullable: false),
          //      PatternUsedInProductId = table.Column<int>(type: "int", nullable: false),
          //      PatternUsedInPoId = table.Column<int>(type: "int", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_PatternStyles", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "People",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      NameFirst = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
          //      NameLast = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
          //      NameMI = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
          //      IsEmployeeFlag = table.Column<bool>(type: "bit", nullable: false),
          //      IsCustomerFlag = table.Column<bool>(type: "bit", nullable: false),
          //      IsVendorFlag = table.Column<bool>(type: "bit", nullable: false),
          //      Photo = table.Column<string>(type: "varchar(MAX)", nullable: true),
          //      DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
          //      Biography = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_People", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "SizeMeasures",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      SizeMeasureName = table.Column<string>(type: "varchar(30)", nullable: false),
          //      SizeMeasureCode = table.Column<string>(type: "varchar(15)", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_SizeMeasures", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "SizeTypes",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      SizeTypeName = table.Column<string>(type: "varchar(30)", nullable: false),
          //      SizeTypeCode = table.Column<string>(type: "varchar(15)", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_SizeTypes", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "StarRatings",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      StarRatingScoreEvent = table.Column<int>(type: "int", nullable: false),
          //      StarRatingScoreAvg = table.Column<decimal>(type: "decimal(1,1)", nullable: false),
          //      PersonId = table.Column<int>(type: "int", nullable: false),
          //      ProductId = table.Column<int>(type: "int", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_StarRatings", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "Styles",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      StyleName = table.Column<string>(type: "varchar(50)", nullable: false),
          //      StyleDescription = table.Column<string>(type: "varchar(50)", nullable: true),
          //      StyleSimilarTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
          //      StyleAssociatedWith = table.Column<string>(type: "varchar(120)", nullable: true),
          //      StyleIsTrendingFlag = table.Column<bool>(type: "bit", nullable: false),
          //      StyleIsTrendingReason = table.Column<string>(type: "varchar(240)", nullable: true)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_Styles", x => x.Id);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "Employees",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      PersonId = table.Column<int>(type: "int", nullable: false),
          //      EmpName = table.Column<string>(type: "varchar(100)", nullable: true),
          //      EmpTitle = table.Column<string>(type: "varchar(100)", nullable: true),
          //      EmpYrsOfService = table.Column<int>(type: "int", nullable: false),
          //      EmpImg = table.Column<string>(type: "varchar(MAX)", nullable: true),
          //      EmpHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          //      EmpSkillsSummary = table.Column<string>(type: "nvarchar(max)", nullable: true)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_Employees", x => x.Id);
          //      table.ForeignKey(
          //                name: "FK_Employees_People_PersonId",
          //                column: x => x.PersonId,
          //                principalTable: "People",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "StarRatingsPeople",
          //    columns: table => new
          //    {
          //      StarRatingId = table.Column<int>(type: "int", nullable: false),
          //      PersonId = table.Column<int>(type: "int", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_StarRatingsPeople", x => new { x.StarRatingId, x.PersonId });
          //      table.ForeignKey(
          //                name: "FK_StarRatingsPeople_People_PersonId",
          //                column: x => x.PersonId,
          //                principalTable: "People",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //      table.ForeignKey(
          //                name: "FK_StarRatingsPeople_StarRatings_StarRatingId",
          //                column: x => x.StarRatingId,
          //                principalTable: "StarRatings",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "Products",
          //    columns: table => new
          //    {
          //      Id = table.Column<int>(type: "int", nullable: false)
          //            .Annotation("SqlServer:Identity", "1, 1"),
          //      ProductNumber = table.Column<int>(type: "int", nullable: false),
          //      Title = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
          //      Summary = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false),
          //      Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
          //      IsMarkedDownFlag = table.Column<bool>(type: "bit", nullable: false),
          //      OnClearanceFlag = table.Column<bool>(type: "bit", nullable: false),
          //      DaysToManufacture = table.Column<int>(type: "int", nullable: false),
          //      SellStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
          //      DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
          //      Poster = table.Column<string>(type: "varchar(MAX)", nullable: true),
          //      Video = table.Column<string>(type: "varchar(MAX)", nullable: true),
          //      ColorId = table.Column<int>(type: "int", nullable: true),
          //      PatternStyleId = table.Column<int>(type: "int", nullable: true),
          //      StyleId = table.Column<int>(type: "int", nullable: true),
          //      SizeMeasureId = table.Column<int>(type: "int", nullable: true),
          //      SizeTypeId = table.Column<int>(type: "int", nullable: true)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_Products", x => x.Id);
          //      table.ForeignKey(
          //                name: "FK_Products_Colors_ColorId",
          //                column: x => x.ColorId,
          //                principalTable: "Colors",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Restrict);
          //      table.ForeignKey(
          //                name: "FK_Products_PatternStyles_PatternStyleId",
          //                column: x => x.PatternStyleId,
          //                principalTable: "PatternStyles",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Restrict);
          //      table.ForeignKey(
          //                name: "FK_Products_SizeMeasures_SizeMeasureId",
          //                column: x => x.SizeMeasureId,
          //                principalTable: "SizeMeasures",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Restrict);
          //      table.ForeignKey(
          //                name: "FK_Products_SizeTypes_SizeTypeId",
          //                column: x => x.SizeTypeId,
          //                principalTable: "SizeTypes",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Restrict);
          //      table.ForeignKey(
          //                name: "FK_Products_Styles_StyleId",
          //                column: x => x.StyleId,
          //                principalTable: "Styles",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Restrict);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "ProductsCategories",
          //    columns: table => new
          //    {
          //      ProductId = table.Column<int>(type: "int", nullable: false),
          //      CategoryId = table.Column<int>(type: "int", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_ProductsCategories", x => new { x.ProductId, x.CategoryId });
          //      table.ForeignKey(
          //                name: "FK_ProductsCategories_Categories_CategoryId",
          //                column: x => x.CategoryId,
          //                principalTable: "Categories",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //      table.ForeignKey(
          //                name: "FK_ProductsCategories_Products_ProductId",
          //                column: x => x.ProductId,
          //                principalTable: "Products",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "ProductsPeople",
          //    columns: table => new
          //    {
          //      ProductId = table.Column<int>(type: "int", nullable: false),
          //      PersonId = table.Column<int>(type: "int", nullable: false),
          //      Role = table.Column<string>(type: "varchar(50)", nullable: false),
          //      ProductValueAddJob = table.Column<string>(type: "varchar(50)", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_ProductsPeople", x => new { x.ProductId, x.PersonId });
          //      table.ForeignKey(
          //                name: "FK_ProductsPeople_People_PersonId",
          //                column: x => x.PersonId,
          //                principalTable: "People",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //      table.ForeignKey(
          //                name: "FK_ProductsPeople_Products_ProductId",
          //                column: x => x.ProductId,
          //                principalTable: "Products",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //    });

          //migrationBuilder.CreateTable(
          //    name: "StarRatingsProducts",
          //    columns: table => new
          //    {
          //      StarRatingId = table.Column<int>(type: "int", nullable: false),
          //      ProductId = table.Column<int>(type: "int", nullable: false)
          //    },
          //    constraints: table =>
          //    {
          //      table.PrimaryKey("PK_StarRatingsProducts", x => new { x.StarRatingId, x.ProductId });
          //      table.ForeignKey(
          //                name: "FK_StarRatingsProducts_Products_ProductId",
          //                column: x => x.ProductId,
          //                principalTable: "Products",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //      table.ForeignKey(
          //                name: "FK_StarRatingsProducts_StarRatings_StarRatingId",
          //                column: x => x.StarRatingId,
          //                principalTable: "StarRatings",
          //                principalColumn: "Id",
          //                onDelete: ReferentialAction.Cascade);
          //    });

          //migrationBuilder.CreateIndex(
          //    name: "IX_Employees_PersonId",
          //    table: "Employees",
          //    column: "PersonId",
          //    unique: true);

          //migrationBuilder.CreateIndex(
          //    name: "IX_Products_ColorId",
          //    table: "Products",
          //    column: "ColorId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_Products_PatternStyleId",
          //    table: "Products",
          //    column: "PatternStyleId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_Products_SizeMeasureId",
          //    table: "Products",
          //    column: "SizeMeasureId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_Products_SizeTypeId",
          //    table: "Products",
          //    column: "SizeTypeId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_Products_StyleId",
          //    table: "Products",
          //    column: "StyleId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_ProductsCategories_CategoryId",
          //    table: "ProductsCategories",
          //    column: "CategoryId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_ProductsPeople_PersonId",
          //    table: "ProductsPeople",
          //    column: "PersonId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_StarRatingsPeople_PersonId",
          //    table: "StarRatingsPeople",
          //    column: "PersonId");

          //migrationBuilder.CreateIndex(
          //    name: "IX_StarRatingsProducts_ProductId",
          //    table: "StarRatingsProducts",
          //    column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "About");

            //migrationBuilder.DropTable(
            //    name: "Employees");

            //migrationBuilder.DropTable(
            //    name: "ProductsCategories");

            //migrationBuilder.DropTable(
            //    name: "ProductsPeople");

            //migrationBuilder.DropTable(
            //    name: "StarRatingsPeople");

            //migrationBuilder.DropTable(
            //    name: "StarRatingsProducts");

            //migrationBuilder.DropTable(
            //    name: "Categories");

            //migrationBuilder.DropTable(
            //    name: "People");

            //migrationBuilder.DropTable(
            //    name: "Products");

            //migrationBuilder.DropTable(
            //    name: "StarRatings");

            //migrationBuilder.DropTable(
            //    name: "Colors");

            //migrationBuilder.DropTable(
            //    name: "PatternStyles");

            //migrationBuilder.DropTable(
            //    name: "SizeMeasures");

            //migrationBuilder.DropTable(
            //    name: "SizeTypes");

            //migrationBuilder.DropTable(
            //    name: "Styles");
        }
    }
}

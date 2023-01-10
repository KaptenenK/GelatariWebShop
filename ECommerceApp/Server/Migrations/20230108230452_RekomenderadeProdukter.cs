using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class RekomenderadeProdukter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Glass", "glass" },
                    { 2, "Bakelser", "bakelser" },
                    { 3, "Bröd", "bröd" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Gräddglass" },
                    { 3, "Gelato" },
                    { 4, "Sorbé" },
                    { 5, "Fikabröd" },
                    { 6, "Mörka bröd" },
                    { 7, "Ljusa bröd" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Gräddig och god saffransglass som också blir lysande gul av saffranet.", true, "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg", "SaffransGlass" },
                    { 2, 1, "Äkta pistageglass är en av mina absoluta favoriter när det kommer till glass. Den här hemmagjorda varianten blev helt perfekt i både smak och konsistens.", false, "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg", "PistageGlass" },
                    { 3, 1, "Glass med äkta vanilj – gör egen vaniljglass med glassmaskin! Grädde, mjölk och äggulor utgör basen till glassen som får smak av socker, vaniljstång och salt.", false, "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg", "VaniljGlass" },
                    { 4, 2, "Crunchy Choklad Cookies!!", false, "https://bakingamoment.com/wp-content/uploads/2016/09/IMG_0316-chocolate-chip-cookies-1-720x720.jpg", "Choklad Cookie" },
                    { 5, 2, "Krispiga Kolasnittar!", false, "https://ingmar.app/blog/wp-content/uploads/2015/12/kolasnittar2.jpg", "Kola Cookies" },
                    { 6, 2, "Vårt klassiska recept på Vetebullar/Kanelbullar/Vetebröd, samma recept som återfinns på våra vetemjöls-förpackningar!", false, "https://www.kungsornen.se/467791/siteassets/2.-recept/saftigaste-kanelbullarna.jpg?maxwidth=1440", "Kanelbullar" },
                    { 7, 2, "GUDOMLIGT GODA SAFFRANSBULLAR Riktigt, riktigt saftiga och goda saffransbullar! Smörkrämsfyllningen gör bullarna extra saftiga & goda!", true, "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", "Saffransbullar" },
                    { 8, 3, "lkdfkljdsjkfdlkjfdjlsk", false, "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", "SaffransLimpa" },
                    { 9, 3, "-", false, "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", "Bananbröd" },
                    { 10, 3, "földsölkfdöklfölsdöklsfd", true, "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", "BarbariBröd" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 3, 100.0m, 80.0m },
                    { 2, 2, 99.0m, 80.0m },
                    { 3, 4, 99.0m, 70.0m },
                    { 4, 5, 49.0m, 30.0m },
                    { 5, 5, 39.0m, 30.0m },
                    { 6, 5, 99.0m, 80.0m },
                    { 7, 5, 99.0m, 70.0m },
                    { 8, 7, 99.0m, 80.0m },
                    { 9, 7, 99.0m, 80.0m },
                    { 10, 6, 99.0m, 80.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

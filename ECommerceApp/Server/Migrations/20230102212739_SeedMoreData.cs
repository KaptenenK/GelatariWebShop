using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Gräddig och god saffransglass som också blir lysande gul av saffranet.", "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg", 85.00m, "SaffransGlass" },
                    { 2, 1, "Äkta pistageglass är en av mina absoluta favoriter när det kommer till glass. Den här hemmagjorda varianten blev helt perfekt i både smak och konsistens.", "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg", 60.0m, "PistageGlass" },
                    { 3, 1, "Glass med äkta vanilj – gör egen vaniljglass med glassmaskin! Grädde, mjölk och äggulor utgör basen till glassen som får smak av socker, vaniljstång och salt.", "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg", 30.0m, "VaniljGlass" },
                    { 4, 2, "Crunchy Choklad Cookies!!", "https://bakingamoment.com/wp-content/uploads/2016/09/IMG_0316-chocolate-chip-cookies-1-720x720.jpg", 30.0m, "Choklad Cookie" },
                    { 5, 2, "Krispiga Kolasnittar!", "https://ingmar.app/blog/wp-content/uploads/2015/12/kolasnittar2.jpg", 30.0m, "Kola Cookies" },
                    { 6, 2, "Vårt klassiska recept på Vetebullar/Kanelbullar/Vetebröd, samma recept som återfinns på våra vetemjöls-förpackningar!", "https://www.kungsornen.se/467791/siteassets/2.-recept/saftigaste-kanelbullarna.jpg?maxwidth=1440", 30.0m, "Kanelbullar" },
                    { 7, 2, "GUDOMLIGT GODA SAFFRANSBULLAR Riktigt, riktigt saftiga och goda saffransbullar! Smörkrämsfyllningen gör bullarna extra saftiga & goda!", "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", 30.0m, "Saffransbullar" },
                    { 8, 3, "lkdfkljdsjkfdlkjfdjlsk", "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", 30.0m, "SaffransLimpa" },
                    { 9, 3, "-", "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", 30.0m, "Bananbröd" },
                    { 10, 3, "földsölkfdöklfölsdöklsfd", "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg", 30.0m, "BarbariBröd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

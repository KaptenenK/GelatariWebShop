

namespace ECommerceApp.Server.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "SaffransGlass",
                Description = "Gräddig och god saffransglass som också blir lysande gul av saffranet.",
                ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                Price = 85.00m
            },
         new Product
         {
             Id = 2,
             Title = "PistageGlass",
             Description = "Äkta pistageglass är en av mina absoluta favoriter när det kommer till glass. Den här hemmagjorda varianten blev helt perfekt i både smak och konsistens.",
             ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
             Price = 60.0m
         },
         new Product
         {
             Id = 3,
             Title = "VaniljGlass",
             Description = "Glass med äkta vanilj – gör egen vaniljglass med glassmaskin! Grädde, mjölk och äggulor utgör basen till glassen som får smak av socker, vaniljstång och salt.",
             ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
             Price = 30.0m
         }

            );
	}

	public DbSet<Product> Products { get; set; }
}

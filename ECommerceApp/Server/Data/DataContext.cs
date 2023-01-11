

namespace ECommerceApp.Server.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<ProductVariant>().HasKey(p => new { p.ProductId, p.ProductTypeId});

        modelBuilder.Entity<ProductType>().HasData( 
             new ProductType { Id = 1, Name = "Default" },

            new ProductType { Id = 2, Name = "Gräddglass" },

            new ProductType { Id = 3, Name = "Gelato" },

            new ProductType { Id = 4, Name = "Sorbé" },

            new ProductType { Id = 5, Name = "Fikabröd" },

            new ProductType { Id = 6, Name = "Mörka bröd" },

            new ProductType { Id = 7, Name = "Ljusa bröd" }
         
            );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Glass",
                Url = "glass",
            },

             new Category
             {
                 Id = 2,
                 Name = "Bakelser",
                 Url = "bakelser",
             },

              new Category
              {
                  Id = 3,
                  Name = "Bröd",
                  Url = "bröd",
              }

            );


        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "SaffransGlass",
                Description = "Gräddig och god saffransglass som också blir lysande gul av saffranet.",
                ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",

                CategoryId = 1,
                Featured = true
            },
         new Product
         {
             Id = 2,
             Title = "PistageGlass",
             Description = "Äkta pistageglass är en av mina absoluta favoriter när det kommer till glass. Den här hemmagjorda varianten blev helt perfekt i både smak och konsistens.",
             ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",

             CategoryId = 1
         },
         new Product
         {
             Id = 3,
             Title = "VaniljGlass",
             Description = "Glass med äkta vanilj – gör egen vaniljglass med glassmaskin! Grädde, mjölk och äggulor utgör basen till glassen som får smak av socker, vaniljstång och salt.",
             ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",

             CategoryId = 1
         },
         new Product
         {
             Id = 4,
             Title = "Choklad Cookie",
             Description = "Crunchy Choklad Cookies!!",
             ImageUrl = "https://bakingamoment.com/wp-content/uploads/2016/09/IMG_0316-chocolate-chip-cookies-1-720x720.jpg",

             CategoryId = 2
         },
         new Product
         {
             Id = 5,
             Title = "Kola Cookies",
             Description = "Krispiga Kolasnittar!",
             ImageUrl = "https://ingmar.app/blog/wp-content/uploads/2015/12/kolasnittar2.jpg",

             CategoryId = 2
         },
         new Product
         {
             Id = 6,
             Title = "Kanelbullar",
             Description = "Vårt klassiska recept på Vetebullar/Kanelbullar/Vetebröd, samma recept som återfinns på våra vetemjöls-förpackningar!",
             ImageUrl = "https://www.kungsornen.se/467791/siteassets/2.-recept/saftigaste-kanelbullarna.jpg?maxwidth=1440",
             CategoryId = 2
         },
         new Product
         {
             Id = 7,
             Title = "Saffransbullar",
             Description = "GUDOMLIGT GODA SAFFRANSBULLAR Riktigt, riktigt saftiga och goda saffransbullar! Smörkrämsfyllningen gör bullarna extra saftiga & goda!",
             ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
             CategoryId = 2,
             Featured = true
         },
         new Product
         {
             Id = 8,
             Title = "SaffransLimpa",
             Description = "lkdfkljdsjkfdlkjfdjlsk",
             ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
             CategoryId = 3
         },
         new Product
         {
             Id = 9,
             Title = "Bananbröd",
             Description = "-",
             ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
             CategoryId = 3
         },
         new Product
         {
             Id = 10,
             Title = "BarbariBröd",
             Description = "földsölkfdöklfölsdöklsfd",
             ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
             CategoryId = 3,
             Featured = true
         }

            ) ;

        modelBuilder.Entity<ProductVariant>().HasData(
            new ProductVariant
            {
                ProductId= 1,
                ProductTypeId = 3,
                Price = 80.0m,
                OriginalPrice = 100.0m
            },
            new ProductVariant
            {
                ProductId = 2,
                ProductTypeId = 2,
                Price = 80.0m,
                OriginalPrice = 99.0m
            },
            new ProductVariant
            {
                ProductId = 3,
                ProductTypeId = 4,
                Price = 70.0m,
                OriginalPrice = 99.0m
            },
            new ProductVariant
            {
                ProductId = 4,
                ProductTypeId = 5,
                Price = 30.0m,
                OriginalPrice = 49.0m
            },
            new ProductVariant
            {
                ProductId = 5,
                ProductTypeId = 5,
                Price = 30.0m,
                OriginalPrice = 39.0m
            },
            new ProductVariant
            {
                ProductId = 6,
                ProductTypeId = 5,
                Price = 80.0m,
                OriginalPrice = 99.0m
            },
            new ProductVariant
            {
                ProductId = 7,
                ProductTypeId = 5,
                Price = 70.0m,
                OriginalPrice = 99.0m
            },
            new ProductVariant
            {
                ProductId = 8,
                ProductTypeId = 7,
                Price = 80.0m,
                OriginalPrice = 99.0m
            },
            new ProductVariant
            {
                ProductId = 9,
                ProductTypeId = 7,
                Price = 80.0m,
                OriginalPrice = 99.0m
            },
            new ProductVariant
            {
                ProductId = 10,
                ProductTypeId = 6,
                Price = 80.0m,
                OriginalPrice = 99.0m
            }


            );
	}

	
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
}

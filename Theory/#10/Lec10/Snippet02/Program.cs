using Snippet02;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;


[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Snippet02
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            //FilteredIncludes();
            //QueryingProducts();
            //QueryingWithLike();

            //DataLoadingSchemasLazy();
            //DataLoadingSchemasExplicit();

            //add
            //if (AddProduct(6, "Bob's Burgers", 500M))
            //{
            //    Console.WriteLine("Add product successful.");
            //}

            //update
            //if(IncreaseProductPrice("Bob",20M))
            //{
            //    Console.WriteLine("Product price has been updated");
            //}

            //delete
            //int deleted = DeleteProducts("Bob");
            //Console.WriteLine($"{deleted} product(s) were deleted.");

            //transaction
            //int deleted = DeleteProductsTransaction("Bob");
            //Console.WriteLine($"{deleted} product(s) were deleted.");

            //ListProducts();



            //LINQ
            //FilterAndSort();
            //AnonymousType();
            //JoinCategoriesAndProducts();

            //UseLinqToSQL();

            using (var db = new NorthwindContext())
            {
                var q = db.Employees.Where(e => e.FirstName.StartsWith("S"));

                foreach (var e in q)
                {
                    Console.WriteLine(e.FirstName+":"+e.LastName);
                }    
            }


        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Console.WriteLine("Categories and how many products they have:");

                IQueryable<Category> categories = db.Categories.Include(c => c.Products);

                foreach (var c in categories)
                {
                    Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                }
            }
        }

        static void FilteredIncludes()
        {
            using (var db = new Northwind())
            {
                Console.WriteLine("Enter a minimum for units in stock:");
                string unitInStock = Console.ReadLine();
                int stock = int.Parse(unitInStock);

                IQueryable<Category> categories = db.Categories.Include(c => c.Products.Where(p => p.Stock >= stock));

                foreach (var cat in categories)
                {
                    Console.WriteLine($"{cat.CategoryName} has {cat.Products.Count} products with a minimum of {stock} units in stock");

                    foreach (var p in cat.Products)
                    {
                        Console.WriteLine($"{p.ProductName} has {p.Stock} units in stock");
                    }
                    {

                    }

                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                //var loggerFactory = db.GetService<ILoggerFactory>();
                //loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Console.WriteLine("Products that cost more than a price. highest at top");

                string input;
                decimal price;
                do
                {
                    Console.WriteLine("Enter a product price:");
                    input = Console.ReadLine();
                }
                while (!decimal.TryParse(input, out price));

                IQueryable<Product> products = db.Products.Where(p => p.Cost > price).OrderByDescending(p => p.Cost);

                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.ProductID}: {prod.ProductName} costs {prod.Cost:$#,##0.00} and has {prod.Stock} in stock.");
                }

                Console.WriteLine("Query string:");
                Console.WriteLine(products.ToQueryString());
            }
        }

        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                Console.WriteLine("Enter part of a product name: ");
                string input = Console.ReadLine();

                IQueryable<Product> products = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                foreach (var p in products)
                {
                    Console.WriteLine($"{p.ProductName} has {p.Stock} in stock. Dicontinued: {p.Discontinued}");
                }
            }
        }

        static void DataLoadingSchemasLazy()
        {
            //Ленивая загрузка
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());


                Console.WriteLine("Categories and how many products they have:");

                IQueryable<Category> categories = db.Categories;

                foreach (var c in categories)
                {
                    Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                }
            }
        }

        static void DataLoadingSchemasExplicit()
        {
            using (var db = new Northwind())
            {
                IQueryable<Category> categories;

                db.ChangeTracker.LazyLoadingEnabled = false;

                Console.WriteLine("Enable eager loading? (Y/N):");
                bool eagerLoading = (Console.ReadKey().Key == ConsoleKey.Y);
                bool explicitLoading = false;
                Console.WriteLine();

                if (eagerLoading)
                {
                    categories = db.Categories.Include(c => c.Products);
                }
                else
                {
                    categories = db.Categories;

                    Console.WriteLine("Enable explicit loading? (Y/N): ");
                    explicitLoading = (Console.ReadKey().Key == ConsoleKey.Y);
                    Console.WriteLine();
                }

                foreach (var c in categories)
                {
                    if (explicitLoading)
                    {
                        Console.WriteLine($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                        var key = Console.ReadKey().Key;
                        Console.WriteLine();
                        if (key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded)
                            {
                                products.Load();
                            }
                        }
                    }
                    Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product()
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                db.Products.Add(newProduct);

                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                Console.WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}", "ID", "Product Name", "Cost", "Stock", "Disc.");

                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    Console.WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}", item.ProductID, item.ProductName, item.Cost, item.Stock, item.Discontinued);
                }
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));

                if (updateProduct != null)
                {
                    updateProduct.Cost += amount;
                    int affected = db.SaveChanges();
                    return (affected == 1);
                }
                return false;
            }
        }

        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));

                db.Products.RemoveRange(products);
                return db.SaveChanges();
            }
        }

        static int DeleteProductsTransaction(string name)
        {
            using (var db = new Northwind())
            {
                using (IDbContextTransaction t = db.Database.BeginTransaction())
                {
                    Console.WriteLine("Transaction isolation level: {0}", t.GetDbTransaction().IsolationLevel);

                    var products = db.Products.Where(p => p.ProductName.StartsWith(name));

                    db.Products.RemoveRange(products);
                    int affected = db.SaveChanges();
                    t.Commit();
                    return affected;
                }
            }
        }

        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = from p in db.Products
                            where p.Cost < 10M
                            orderby p.Cost descending
                            select p;

                //var q = db.Products.Where(p => p.Cost < 10M).OrderByDescending(p => p.Cost);

                Console.WriteLine("Products that cost less than $10:");
                foreach (var q in query)
                {
                    Console.WriteLine("{0}: {1} costs ${2}", q.ProductID, q.ProductName, q.Cost);
                }
            }
        }

        static void AnonymousType()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    .Where(product => product.Cost < 10M)
                    .OrderByDescending(product => product.Cost)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.Cost
                    });
                Console.WriteLine("Products that cost less than $10 with anonymous types:");
                foreach (var q in query)
                {
                    Console.WriteLine("{0}: {1} costs ${2}", q.ProductID, q.ProductName, q.Cost);
                }
            }
        }

        static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // присоединяем каждый товар к своей категории,
                // чтобы вернуть 77 совпадений
                var queryJoin = db.Categories.Join(
                inner: db.Products,
                outerKeySelector: category => category.CategoryID,
                innerKeySelector: product => product.CategoryID,
                resultSelector: (c, p) =>
                new { c.CategoryName, p.ProductName, p.ProductID });
                foreach (var item in queryJoin)
                {
                    Console.WriteLine("{0}: {1} is in {2}.",
                    arg0: item.ProductID,
                    arg1: item.ProductName,
                    arg2: item.CategoryName);
                }
            }
        }

        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // группируем все товары по соответствующим категориям,
                // чтобы вернуть восемь совпадений
                var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                inner: db.Products,
                outerKeySelector: category => category.CategoryID,
                innerKeySelector: product => product.CategoryID,
                resultSelector: (c, matchingProducts) => new {
                    c.CategoryName,
                    Products = matchingProducts.OrderBy(p => p.ProductName)
                });
                foreach (var item in queryGroup)
                {
                    Console.WriteLine("{0} has {1} products.",arg0: item.CategoryName, arg1: item.Products.Count());
                    foreach (var product in item.Products)
                    {
                        Console.WriteLine($" {product.ProductName}");
                    }
                }
            }
        }

        static void UseLinqToSQL()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Northwind;User ID=sa;Password=HelloWorld10;";
            var db = new NorthwindDbDataContext(connectionString);

            var query = from r in db.Region
                    join t in db.Territories on r.RegionID equals t.RegionID
                    select new
                    {
                        t.TerritoryDescription,
                        r.RegionDescription
                    };
            if(query.Any())
            {
                foreach(var row in query)
                {
                    Console.WriteLine($"{row.TerritoryDescription} {row.RegionDescription}");
                }
            }
            
        }
    }
}
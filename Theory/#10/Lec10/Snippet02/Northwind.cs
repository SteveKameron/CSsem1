using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Snippet02
{
    internal class Northwind : DbContext
    {
        //свойства, сопоставляемые с таблицами в БД
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Northwind;User ID=sa;Password=HelloWorld10;";
            optionsBuilder.UseSqlServer(connectionString);

            //string connectionString = "Data Source=localhost;Initial Catalog=Northwind;User ID=sa;Password=HelloWorld10;MultipleActiveResultSets=True;";
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);//lazy loading

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //пример использования FluentAPI 
            //для установления свойства Required
            //и установки максимальной длины имени категории в 15 символов
            model.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()//Required = true
                .HasMaxLength(15);//макс. длина

            // добавлено "исправление" отсутствия поддержки
            // десятичных чисел в SQLite
            model.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();

            //фильтр
            
        }
    }
}

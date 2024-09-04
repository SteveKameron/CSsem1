using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet02
{
    internal class Category
    {
        // эти свойства соотносятся со столбцами в базе данных
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }

        // навигационное свойство для связанных строк
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            // чтобы позволить разработчикам добавлять товары в Category,
            // мы должны инициализировать навигационное свойство пустым списком
            this.Products = new HashSet<Product>();
        }

    }
}

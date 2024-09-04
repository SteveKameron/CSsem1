using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet02
{
    internal class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        //имя свойства не совпадает с именем столбца
        [Column("UnitPrice", TypeName ="money")]
        public decimal? Cost { get; set; }

        [Column("UnitsInStock")]
        public short? Stock { get; set; }

        public bool Discontinued { get; set; }


        //эти две строки определяют связь внешнего ключа
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}

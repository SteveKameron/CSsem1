using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
        
		//Db primary key
        public int Id { get; set; }

		//Nullable string
		public string? Title { get; set; }

		//Restrict any other data types other than Date
		//This field will contain Date only without Time part
		[DataType(DataType.Date)]
		//[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
		public string? Genre { get; set; }
		
		//[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
		
    }
}






///Validation
//public int Id { get; set; }

//[StringLength(60, MinimumLength = 3)]
//[Required]
//public string Title { get; set; } = string.Empty;

//// [Display(Name = "Release Date")]
//[DataType(DataType.Date)]
//public DateTime ReleaseDate { get; set; }

//[Range(1, 100)]
//[DataType(DataType.Currency)]
//[Column(TypeName = "decimal(18, 2)")]
//public decimal Price { get; set; }

//[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
//[Required]
//[StringLength(30)]
//public string Genre { get; set; } = string.Empty;
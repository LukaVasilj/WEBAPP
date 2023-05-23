using System.ComponentModel.DataAnnotations;

namespace WEBAPP.Models
{
    public class Genre
    {
        [Key]

         public int genreid { get; set; }

       
         public string? genrename { get; set; }
    }
}

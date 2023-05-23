using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPP.Models
{
    public class Movie
    {
        [Key]

        public int movieid { get; set; }

        public string title { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime releasedate { get; set; }

        public int genreid { get; set; }

        public string director { get; set; }

        public string description { get; set; }

        public ICollection<Showtime>? showtimes { get; set; }


    }
}

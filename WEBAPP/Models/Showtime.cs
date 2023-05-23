using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPP.Models
{
    public class Showtime
    {
        [Key]

        public int showtimeid { get; set; }

        public int theaterid { get; set; }
        public virtual Theater? theaters { get; set; }

        public int movieid { get; set; }
        public virtual Movie? movies { get; set; }

        public decimal price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime starttime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime endtime { get; set; }

        


    }
}

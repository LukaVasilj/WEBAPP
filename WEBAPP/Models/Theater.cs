using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPP.Models
{
    public class Theater
    {
        [Key]

        public int theaterid { get; set; }

        public string name { get; set; }

        public int capacity { get; set; }

        public ICollection<Showtime> showtimes { get; set; }

    }
}

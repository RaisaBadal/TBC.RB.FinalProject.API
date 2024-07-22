using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB.TBC.FinalProject.Domain.Entitites
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public string BookId { get; set; }
        public string title { get; set; }
        public IEnumerable<string> authors { get; set; }
        public string imageLink { get; set; }
        public string description { get; set; }

        public IEnumerable<Favorite> FavoriteByUser { get; set; }
    }
}

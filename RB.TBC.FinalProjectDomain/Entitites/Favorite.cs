using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB.TBC.FinalProject.Domain.Entitites
{

    [Table("Favorites")]
    public class Favorite
    {

        [Key]
        public string FavoriteId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Book")]
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}

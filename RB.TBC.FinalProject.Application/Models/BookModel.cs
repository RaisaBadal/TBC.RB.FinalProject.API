using System.ComponentModel.DataAnnotations;

namespace RB.TBC.FinalProject.Application.Models
{
    public class BookModel
    {
        [Required]
        public string title { get; set; }
        public IEnumerable<string> authors { get; set; }

        [Required]
        public string imageLink { get; set; }
        [Required]
        public string description { get; set; }

    }
}

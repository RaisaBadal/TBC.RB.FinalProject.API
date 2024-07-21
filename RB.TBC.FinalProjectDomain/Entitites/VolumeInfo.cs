using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB.TBC.FinalProject.Domain.Entitites
{
    [Table("VolumeInfo")]
    public class VolumeInfo
    {
        [Key]
        public string VolumeInfoId { get; set; }
        public string title { get; set; }
        public IEnumerable<string> authors { get; set; }

        [ForeignKey("imageLinks")]
        public string imageLinksId { get; set; }
        public ImageLinks imageLinks { get; set; }
        public string description { get; set; }
        public Book Book { get; set; }
    }
}

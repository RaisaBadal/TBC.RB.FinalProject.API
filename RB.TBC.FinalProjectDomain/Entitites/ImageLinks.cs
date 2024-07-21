using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB.TBC.FinalProject.Domain.Entitites
{
    [Table("ImageLinks")]
    public class ImageLinks
    {
        [Key]
        public string ImageId { get; set; }
        public string VolumeInfo { get; set; }

        public VolumeInfo info { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB.TBC.FinalProject.Domain.Entitites
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("VolumeInfo")]
        public  string VolumeInfoId { get; set; }
        public VolumeInfo VolumeInfo { get; set; }
    }
}

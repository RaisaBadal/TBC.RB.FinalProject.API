using System.ComponentModel.DataAnnotations;

namespace RB.TBC.FinalProject.Application.Models
{
    public class FeadbackModel
    {
        [StringLength(100, ErrorMessage = "no correct  format")]
        public required string FeadBack { get; set; }

        [Range(0, 100)]
        public int RatingGivedByUser { get; set; }

    }
}

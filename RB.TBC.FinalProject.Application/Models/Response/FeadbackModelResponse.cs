using RB.TBC.FinalProject.Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace RB.TBC.FinalProject.Application.Models.Response
{
    public class FeadbackModelResponse
    {
        public required string FeadBack { get; set; }

        [Range(0, 100)]
        public int RatingGivedByUser { get; set; }

        public UserRegisterRequest User { get; set; }
    }
}

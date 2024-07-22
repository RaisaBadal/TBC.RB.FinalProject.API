using System.ComponentModel.DataAnnotations;

namespace RB.TBC.FinalProject.Domain.Entitites
{
    public class User
    {
        [Key] 
        public string UserId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public IEnumerable<Feadback> Feadbacks { get; set; }
        public IEnumerable<Favorite> FavoriteBooks { get; set; }
    }
}

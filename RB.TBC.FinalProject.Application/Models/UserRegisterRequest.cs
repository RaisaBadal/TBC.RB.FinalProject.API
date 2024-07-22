namespace RB.TBC.FinalProject.Application.Models
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ImageUrl { get; set; }
    }
}

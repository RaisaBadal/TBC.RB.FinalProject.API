using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Application.Persistance;
using RB.TBC.FinalProject.Domain.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RB.TBC.FinalProjectAPI.Controllers
{
    /// <summary>
    /// Controller for authentication operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TbcDbContext _context;
        private readonly string _key;
        private readonly SmtpService _ser;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="ser">The SMTP service for sending emails.</param>
        public AuthController(TbcDbContext context, SmtpService ser)
        {
            _context = context;
            _ser = ser;
            _key = "KkQlFp7eupD0YdLsKynGpEZ6gY0N6J4I2V57E8E";
        }

        /// <summary>
        /// Authenticates the user and returns a JWT token.
        /// </summary>
        /// <param name="user">The sign-in request containing username and password.</param>
        /// <returns>Returns an Ok result with the JWT token if authentication is successful; otherwise, Unauthorized.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] SignInRequest user)
        {
            var dbUser = _context.Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if (dbUser == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.UserId),
                    new Claim(ClaimTypes.Name, dbUser.Name),
                    new Claim(ClaimTypes.Surname, dbUser.Surname),
                    new Claim(ClaimTypes.DateOfBirth, dbUser.BirthDate),
                    new Claim(ClaimTypes.Email, dbUser.Email),
                    new Claim(ClaimTypes.MobilePhone, dbUser.PhoneNumber),
                    new Claim(ClaimTypes.UserData, dbUser.UserName),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var recipientName = $"{dbUser.Name} {dbUser.Surname}";
            var emailContent = $@"
            <html>
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Security Alert</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f8f9fa;
                            margin: 0;
                            padding: 0;
                            color: #333;
                        }}
                        .container {{
                            width: 80%;
                            max-width: 600px;
                            margin: 50px auto;
                            padding: 20px;
                            background-color: #fff;
                            border-radius: 10px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }}
                        .greeting {{
                            color: #3366cc;
                            font-size: 18px;
                            margin-bottom: 20px;
                        }}
                        .content {{
                            font-size: 16px;
                            line-height: 1.6;
                            margin-bottom: 20px;
                        }}
                        .signature {{
                            color: #ff6600;
                            font-size: 16px;
                            margin-top: 20px;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <p class=""greeting"">Dear <span>{recipientName}</span>,</p>
                        <div class=""content"">
                            <p>We noticed a new sign-in to your RB Library account. If this was you, there's no need for further action. 
                            However, if you didn't initiate this sign-in, please contact us immediately, and we will assist you in securing your account.</p>
                            <p>Thank you for your attention to this matter.</p>
                        </div>
                        <p class=""signature"">Sincerely,<br/>Your RB Library Team</p>
                    </div>
                </body>
            </html>";

            _ser.SendMessage(dbUser.Email,
                $"Security Alert: New Sign-in to Your RB Library Account {DateTime.Now.ToShortTimeString()}",
                emailContent);

            return Ok(new { Token = tokenString });
        }

        /// <summary>
        /// Registers a new user and sends a welcome email.
        /// </summary>
        /// <param name="user">The user registration request containing user details.</param>
        /// <returns>Returns an Ok result if registration is successful; otherwise, BadRequest.</returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest user)
        {
            if (_context.Users.Any(u => u.UserName == user.UserName))
            {
                return BadRequest("Username is already taken.");
            }

            _context.Users.Add(new FinalProject.Domain.Entitites.User
            {
                BirthDate = user.BirthDate,
                Surname = user.Surname,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                ImageUrl=user.ImageUrl,
                UserId = Guid.NewGuid().ToString(),
            });
            _context.SaveChanges();

            var body = @"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Welcome to RB Library!</title>
                    <style>
                        body {
                            font-family: Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f8f9fa;
                            color: #333;
                        }
                        .container {
                            width: 60%;
                            max-width: 800px;
                            margin: 50px auto;
                            padding: 20px;
                            background-color: #fff;
                            border-radius: 10px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }
                        .header {
                            text-align: center;
                            color: #007bff;
                            font-size: 28px;
                            margin-bottom: 20px;
                            font-weight: bold;
                        }
                        .content {
                            font-size: 18px;
                            line-height: 1.6;
                        }
                        .content p {
                            margin-bottom: 15px;
                        }
                        .list-item {
                            font-size: 18px;
                            color: #333;
                            margin-left: 20px;
                        }
                        .security-notice {
                            background-color: #f1f1f1;
                            padding: 15px;
                            border-radius: 5px;
                            margin-top: 30px;
                            text-align: center;
                            color: #555;
                            font-size: 16px;
                        }
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <div class=""header"">
                            Welcome to RB Library!
                        </div>
                        <div class=""content"">
                            <p>Dear,</p>
                            <p>Congratulations on creating your account.</p>
                            <p>We are excited to have you on board!</p>
                            <p>Here are some next steps to get started:</p>
                            <ul>
                                <li class=""list-item"">Explore our features and services.</li>
                                <li class=""list-item"">Customize your profile settings.</li>
                                <li class=""list-item"">Contact our support team if you need any assistance.</li>
                            </ul>
                            <p>Thank you for choosing RB Library!</p>
                        </div>
                        <div class=""security-notice"">
                            For security reasons, please do not share this email with anyone.
                        </div>
                    </div>
                </body>
                </html>";

            _ser.SendMessage(user.Email, "Welcome to RB Library! Get Started Today", body);
            return Ok(new { Message = "Registration successful" });
        }
    }
}

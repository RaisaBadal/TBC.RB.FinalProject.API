using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Application.Persistance;

namespace RB.TBC.FinalProject.Application.Services
{
    public class ContactUsService : IContactUsService
    {

        private readonly SmtpService smtp;
        public ContactUsService(SmtpService ser)
        {
            smtp = ser;
        }

        public bool SendMesaggeToAdmin(ContactUsModel model)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(model, "model");

                string body = $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>{model.Subject}</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }}
        .container {{
            width: 100%;
            max-width: 600px;
            margin: 0 auto;
            background-color: #ffffff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            overflow: hidden;
        }}
        .header {{
            background-color: #4CAF50;
            color: #ffffff;
            padding: 20px;
            text-align: center;
        }}
        .header h1 {{
            margin: 0;
        }}
        .content {{
            padding: 20px;
        }}
        .content h2 {{
            color: #333333;
        }}
        .content p {{
            line-height: 1.6;
            color: #666666;
        }}
        .footer {{
            background-color: #f4f4f4;
            color: #666666;
            padding: 10px;
            text-align: center;
            font-size: 14px;
        }}
        .footer a {{
            color: #4CAF50;
            text-decoration: none;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <h1>News Message</h1>
        </div>
        <div class=""content"">
            <h2>Name: {model.Name}</h2>
            <p> Email: {model.Email}</p>
             <p> Subject:{model.Subject}</p>
            <p> Description:{model.Description}</p>
        <div class=""footer"">
            <p>&copy; 2024 RB Library. All rights reserved.</p>
            <p>If you no longer wish to receive these emails, you can <a href=""#"">unsubscribe here</a>.</p>
        </div>
    </div>
</body>
</html>
";
                smtp.SendMessage("raisa.badalova132@ens.tsu.ge", $"New Message From Customer {DateTime.Now.ToShortDateString()}", body);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

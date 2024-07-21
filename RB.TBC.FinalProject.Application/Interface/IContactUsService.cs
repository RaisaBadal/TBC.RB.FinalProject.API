using RB.TBC.FinalProject.Application.Models;

namespace RB.TBC.FinalProject.Application.Interface
{
    public interface IContactUsService
    {

        bool SendMesaggeToAdmin(ContactUsModel model);
    }
}

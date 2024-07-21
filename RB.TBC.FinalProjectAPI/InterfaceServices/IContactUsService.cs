using RB.TBC.FinalProjectAPI.Models;

namespace RB.TBC.FinalProjectAPI.InterfaceServices
{
    public interface IContactUsService
    {

        bool SendMesaggeToAdmin(ContactUsModel model);
    }
}

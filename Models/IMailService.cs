using System.Threading.Tasks;

namespace ems.Models
{
    public interface IMailService
    {
        Task<int> SendEmailAsync(MailRequest mailRequest);
        Task SendPass(MailRequest mailRequest);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Service.EmailService.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest, string employeeType);
    }
}

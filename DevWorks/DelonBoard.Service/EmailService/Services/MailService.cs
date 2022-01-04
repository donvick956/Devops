using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MailKit.Security;
using System.Text;
using System.Threading.Tasks;
using DelonBoard.Service.EmailService.PdfParser;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Reflection;

namespace DelonBoard.Service.EmailService.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest, string employeeType)
        {
            var mailMessage = new MimeMessage();
            mailMessage.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            mailMessage.To.Add(MailboxAddress.Parse(mailRequest.Recipient));
            mailMessage.Cc.Add(MailboxAddress.Parse("hr@delonllc.com"));

            mailMessage.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();

            // updating placeholders to user values
            var htmlToSend = await UpdatePlaceHolders(await GetEmailBody(employeeType), mailRequest.PlaceHolders);

            // writing to pdf
            File.WriteAllText(@"..\.\DelonBoard\wwwroot\EmailTemplate\Offers\FinalEmail.html", htmlToSend);
            await PdfConverter.PdfConvert(@"..\.\DelonBoard\wwwroot\EmailTemplate\Offers\FinalEmail.html",
                @"..\.\DelonBoard\wwwroot\EmailTemplate\OffersPdf\Document.pdf");

            builder.Attachments.Add(@"..\.\DelonBoard\wwwroot\EmailTemplate\OffersPdf\Document.pdf");

            builder.TextBody = mailRequest.Content;
            mailMessage.Body = builder.ToMessageBody();
            mailMessage.Priority = (MessagePriority)MailPriority.High;


            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(mailMessage);
            smtp.Disconnect(true);
        }

        public async Task<string> GetEmailBody(string employeeType)
        {
            string body;

            if (employeeType == "Regular Contract")
            {
                body = File.ReadAllText(@"..\.\DelonBoard\wwwroot\EmailTemplate\RegularContract.html");
            }else if (employeeType == "Developer Contract")
	        {
                body = File.ReadAllText(@"..\.\DelonBoard\wwwroot\EmailTemplate\DeveloperContract.html");
	        }else
	        {
                body = File.ReadAllText(@"..\.\DelonBoard\wwwroot\EmailTemplate\FullTime.html");
	        }
            return body;
        }

        public async Task<string> UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrWhiteSpace(text) && keyValuePairs != null)
            {
                foreach (var item in keyValuePairs)
                {
                    if (text.Contains(item.Key))
                    {
                        text = text.Replace(item.Key, item.Value);
                    }
                }
            }

            return text;
        }
    }
}

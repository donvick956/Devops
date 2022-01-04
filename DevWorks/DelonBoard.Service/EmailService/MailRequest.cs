using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DelonBoard.Service.EmailService
{
    //Trying out.

    public class MailRequest
    {
        public string Recipient { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }
    }
}

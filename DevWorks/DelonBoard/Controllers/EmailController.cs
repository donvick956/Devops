using DelonBoard.Service.EmailService;
using DelonBoard.Service.EmailService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelonBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IMailService mailService;

        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                request.PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{DATE}}", Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"))),
                    new KeyValuePair<string, string>("{{STREET NUMBER AND STREET NAME}}", "42, Aderupoko street,"),
                    new KeyValuePair<string, string>("{{MORE ADDRESS}}", "Iwaya,"),
                    new KeyValuePair<string, string>("{{CITY, STATE}}", "Yaba-Lagos."),
                    new KeyValuePair<string, string>("{{FIRST NAME}}", "Toyin"),
                    new KeyValuePair<string, string>("{{LAST NAME}}", "Onagoruwa"),
                    new KeyValuePair<string, string>("{{JOB TYPE}}", "Software Engineer"),
                    new KeyValuePair<string, string>("{{CONTRACT DURATION}}", "12 months."),
                    new KeyValuePair<string, string>("{{DESIGNATION}}", "Software Engineer II"),
                    new KeyValuePair<string, string>("{{LINE MANAGER}}", "Mr. Hope Ndudim"),
                    new KeyValuePair<string, string>("{{RESUMPTION DATE}}", "December 23th 2021"),
                    new KeyValuePair<string, string>("{{BRANCH OFFICE ADDRESS}}", "214, ALFRED REWANE, VI, Lagos"),
                    new KeyValuePair<string, string>("{{STAFF NUMBER}}", "DLN-347-OHJ"),
                    new KeyValuePair<string, string>("{{ANNUAL GROSS SALARY}}", "₦4,400,000.00"),
                    new KeyValuePair<string, string>("{{OFFICE HOURS}}", "9:00 a.m. to 5:00 p.m."),
                    new KeyValuePair<string, string>("{{WORK DAYS}}", "Monday to Friday"), 
                    new KeyValuePair<string, string>("{{FIRST NAME  LAST NAME}}", "Toyin Onagoruwa"),
                };

                await mailService.SendEmailAsync(request, "Regular Contract");
                return Ok();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

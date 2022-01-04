using IronPdf;
using System.Net.Mail;
using System.IO;
using System;
using iText.Html2pdf;
using System.Threading.Tasks;

namespace DelonBoard.Service.EmailService.PdfParser
{
    class PdfConverter
    {
        public async static Task PdfConvert(string htmlPath, string pdfPath)
        {
            HtmlConverter.ConvertToPdf(new FileInfo(htmlPath), new FileInfo(pdfPath));
        }
    }
}

using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "file1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Travel Agency  Pdf Report");

            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/file1.pdf", "application/pdf", "file1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "file2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Guest Name");
            pdfPTable.AddCell("Guest Surname");
            pdfPTable.AddCell("Guest Identity No");

            pdfPTable.AddCell("Samuel");
            pdfPTable.AddCell("Beckett");
            pdfPTable.AddCell("11111111110");

            pdfPTable.AddCell("Marcel");
            pdfPTable.AddCell("Proust");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell("Lev");
            pdfPTable.AddCell("Tolstoy");
            pdfPTable.AddCell("44444444445");

            document.Add(pdfPTable);

            document.Close();
            return File("/pdfreports/file2.pdf", "application/pdf", "file2.pdf");
        }
    }
}
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Controllers
{
    public class PdfCreateController : Controller
    {
        private readonly IConverter _converter;
        public PdfCreateController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        public IActionResult CreatePDF(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Payroll Reports",
                Out = $@"C:\Users\admin\source\repos\NominaProject\NominaProject\wwwroot\PDFReports\Department_Nomina_{id}.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                Page = $"https://localhost:5001/PdfExports/Index/{id}",
                WebSettings = {DefaultEncoding="utf-8" },
                FooterSettings = { FontName = "Times New Roman", FontSize = 10, Line = true, Center = "Nominee Project Report" }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Redirect($"/PDFReports/Department_Nomina_{id}.pdf");
        }
    }
}

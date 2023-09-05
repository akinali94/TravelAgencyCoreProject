using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TravelAgencyCoreProject.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationViewModel> DestinationList()
        {
            List<DestinationViewModel> destinationModel = new List<DestinationViewModel>();
            using (var c = new Context())
            {
                destinationModel = c.Destinations.Select(x => new DestinationViewModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModel;
        }
        public IActionResult StaticExcelReport()
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //ExcelPackage excel = new ExcelPackage();
            //var workSheet = excel.Workbook.Worksheets.Add("Page1");
            //workSheet.Cells[1, 1].Value = "Destination";
            //workSheet.Cells[1, 2].Value = "Guide";
            //workSheet.Cells[1, 3].Value = "Capacity";

            //workSheet.Cells[2, 1].Value = "Paris";
            //workSheet.Cells[2, 2].Value = "Amelia PhotoShocker";
            //workSheet.Cells[2, 3].Value = "30";

            //workSheet.Cells[3, 1].Value = "Thailand";
            //workSheet.Cells[3, 2].Value = "Ozai BendFire";
            //workSheet.Cells[3, 2].Value = "45";

            //var bytes = excel.GetAsByteArray();
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "file1.xlsx");

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NewExcel.xlsx");
            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("DestinationList");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "Days and Nights";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Capacity";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NewList.xlsx");
                }
            }
        }
    }
}

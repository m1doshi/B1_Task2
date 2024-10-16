using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Security.Principal;
using System.Text.RegularExpressions;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("importController")]
    public class ImportController : Controller
    {
        private readonly IClassService classService;
        private readonly INewAccountService newAccountService;
        private readonly ITurnoverService turnoverService;
        private readonly IIncomingSaldoService incomingSaldoService;
        private readonly IOutgoingSaldoService outgoingSaldoService;
        public ImportController(IClassService classService, 
            INewAccountService newAccountService, 
            ITurnoverService turnoverService,
            IIncomingSaldoService incomingSaldoService,
            IOutgoingSaldoService outgoingSaldoService)
        {
            this.classService = classService;
            this.newAccountService = newAccountService;
            this.turnoverService = turnoverService;
            this.incomingSaldoService = incomingSaldoService;
            this.outgoingSaldoService = outgoingSaldoService;
        }
        //[HttpGet]
        //public IActionResult Import()
        //{
        //    return View(); // Вернуть представление Import
        //}

        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Incorrect file");
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.End.Row;

                ClassModel newClass = null;
                for (int row = 9; row < rowCount; row++)
                {
                    var currentRow = worksheet.Cells[row, 1].Text.Trim();
                    if (string.IsNullOrEmpty(currentRow) || currentRow == "ПО КЛАССУ" || currentRow == "БАЛАНС" || Regex.IsMatch(currentRow, @"^\d{2}$"))
                    {
                        continue;
                    }
                    if (Regex.IsMatch(currentRow, @"КЛАСС\s*\d+"))
                    {
                        newClass = new ClassModel
                        {
                            Name = currentRow.Substring(8)
                        };
                        await classService.CreateClass(newClass);
                        continue;
                    }
                    var lastClass = await classService.GetLastClass();
                    var account = new NewAccountModel
                    {
                        Id = int.Parse(worksheet.Cells[row, 1].Text),
                        ClassId = lastClass.Id
                    };
                    await newAccountService.CreateAccount(account);
                    var incomingSaldo = new IncomingSaldoModel
                    {
                        Active = decimal.Parse(worksheet.Cells[row, 2].Text),
                        Passive = decimal.Parse(worksheet.Cells[row, 3].Text),
                        AccountId = account.Id
                    };
                    await incomingSaldoService.CreateIncomingSaldo(incomingSaldo);
                    var turnover = new TurnoverModel
                    {
                        Debit = decimal.Parse(worksheet.Cells[row, 4].Text),
                        Credit = decimal.Parse(worksheet.Cells[row, 5].Text),
                        AccountId = account.Id
                    };
                    await turnoverService.CreateTurnover(turnover);
                    var lastIncomingSaldo = await incomingSaldoService.GetLastIncomingSaldo();
                    var lastTurnover = await turnoverService.GetLastTurnover(); 
                    var outgoingSaldo = new OutgoingSaldoModel
                    {
                        Active = decimal.Parse(worksheet.Cells[row, 6].Text),
                        Passive = decimal.Parse(worksheet.Cells[row, 7].Text),
                        IncomingSaldoId = lastIncomingSaldo.Id,
                        TurnoverId = lastTurnover.Id
                    };
                    await outgoingSaldoService.CreateOutgoingSaldo(outgoingSaldo);
                }
            }
            return Ok("File imported successfully.");
        }
    }
}

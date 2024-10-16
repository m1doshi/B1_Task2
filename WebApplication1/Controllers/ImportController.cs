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
    public class ImportController : ControllerBase
    {
        private readonly IClassService classService;
        private readonly IAccountService accountService;
        private readonly ITransactionService transactionService;
        public ImportController(IClassService classService, IAccountService accountService, ITransactionService transactionService)
        {
            this.classService = classService;
            this.accountService = accountService;
            this.transactionService = transactionService;
        }

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
                    if (string.IsNullOrEmpty(currentRow))
                    {
                        continue;
                    }
                    if (currentRow == "ПО КЛАССУ" || currentRow == "БАЛАНС" || Regex.IsMatch(currentRow, @"^\d{2}$"))
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
                    var account = new AccountModel
                    {
                        Id = int.Parse(worksheet.Cells[row, 1].Text),
                        IncomingSaldoActive = decimal.Parse(worksheet.Cells[row, 2].Text),
                        IncomingSaldoPassive = decimal.Parse(worksheet.Cells[row, 3].Text),
                        ClassId = lastClass.Id
                    };
                    await accountService.CreateAccount(account);
                    var transaction = new TransactionModel
                    {
                        AccountId = account.Id,
                        Debit = decimal.Parse(worksheet.Cells[row, 4].Text),
                        Credit = decimal.Parse(worksheet.Cells[row, 5].Text),
                        OutgoingSaldoActive = decimal.Parse(worksheet.Cells[row, 6].Text),
                        OutgoingSaldoPassive = decimal.Parse(worksheet.Cells[row, 7].Text)
                    };
                    await transactionService.CreateTransaction(transaction);
                }
            }
            return Ok("File imported successfully.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Text.RegularExpressions;
using WebApplication1.Models;
using WebApplication1.Services;
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
        private readonly IFileInfoService fileInfoService;
        private readonly DataService dataService;
        public ImportController(IClassService classService, 
            INewAccountService newAccountService, 
            ITurnoverService turnoverService,
            IIncomingSaldoService incomingSaldoService,
            IOutgoingSaldoService outgoingSaldoService,
            IFileInfoService fileInfoService,
            DataService dataService)
        {
            this.classService = classService;
            this.newAccountService = newAccountService;
            this.turnoverService = turnoverService;
            this.incomingSaldoService = incomingSaldoService;
            this.outgoingSaldoService = outgoingSaldoService;
            this.fileInfoService = fileInfoService;
            this.dataService = dataService;
        }
        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ImportExcel(IFormFile file)            //Метод для импорта данных из файла в БД (Views/Import/Import)
        {
            if (file == null || file.Length == 0)
            {
                ViewData["Message"] = "Некорректный файл.";
                return View("Import");
            }
            try
            {
                var fileInfo = new FileInfoModel
                {
                    FileName = file.Name
                };
                await fileInfoService.CreateFileInfo(fileInfo);
                var currentFile = await fileInfoService.GetFileInfoByName(file.Name);
                var currentFileId = currentFile.Id; //Получаю id текущего файла до прохода по всем строкам файла
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.End.Row;

                    ClassModel newClass = null;
                    ClassModel currentClass = null;
                    for (int row = 9; row < rowCount; row++)    //Начинаю проход по всем строкам файла(начиная с 9 строки, т.к. 1-8 нам не нужны)
                    {
                        var currentRow = worksheet.Cells[row, 1].Text.Trim();
                        if (string.IsNullOrEmpty(currentRow)        //Пропускаю ненужные нам строки
                            || currentRow == "ПО КЛАССУ" 
                            || currentRow == "БАЛАНС" 
                            || Regex.IsMatch(currentRow, @"^\d{2}$"))
                        {
                            continue;
                        }
                        if (Regex.IsMatch(currentRow, @"КЛАСС\s*\d+"))  //Нахожу строку в которой написано название класса
                        {
                            currentClass = await classService.GetClassByName(currentRow.Substring(8));
                            if (currentClass == null)
                            {
                                newClass = new ClassModel
                                {
                                    Name = currentRow.Substring(8)
                                };
                                await classService.CreateClass(newClass);
                            }
                            continue;
                        }
                        var lastClass = await classService.GetLastClass();  //Т.к. операции асинхронные, приходится отдельно получать ранее сохраненный в БД класс, чтобы использовать его id
                        var account = new NewAccountModel   
                        {
                            Id = int.Parse(worksheet.Cells[row, 1].Text),
                            ClassId = lastClass.Id,
                            FileId = currentFile.Id
                        };
                        await newAccountService.CreateAccount(account); //Создание нового счёта
                        var incomingSaldo = new IncomingSaldoModel
                        {
                            Active = decimal.Parse(worksheet.Cells[row, 2].Text),
                            Passive = decimal.Parse(worksheet.Cells[row, 3].Text),
                            AccountId = account.Id  //Внешний ключ
                        };
                        await incomingSaldoService.CreateIncomingSaldo(incomingSaldo);  //Создание новой записи с входящим сальдо
                        var turnover = new TurnoverModel
                        {
                            Debit = decimal.Parse(worksheet.Cells[row, 4].Text),
                            Credit = decimal.Parse(worksheet.Cells[row, 5].Text),
                            AccountId = account.Id  //Внешний ключ
                        };
                        await turnoverService.CreateTurnover(turnover); //Создание новой записи с оборотами
                        var lastIncomingSaldo = await incomingSaldoService.GetLastIncomingSaldo();  //Получаю последние добавленные входящее сальдо
                        var lastTurnover = await turnoverService.GetLastTurnover(); //и обороты для того чтобы создать связь с исходящим сальдо
                        var outgoingSaldo = new OutgoingSaldoModel
                        {
                            Active = decimal.Parse(worksheet.Cells[row, 6].Text),
                            Passive = decimal.Parse(worksheet.Cells[row, 7].Text),
                            IncomingSaldoId = lastIncomingSaldo.Id, //Внешний ключ
                            TurnoverId = lastTurnover.Id    //Внешний ключ
                        };
                        await outgoingSaldoService.CreateOutgoingSaldo(outgoingSaldo);  //Создание новой записи исходящего сальдо
                    }
                }
                ViewData["Message"] = "Файл успешно импортирован.";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Ошибка при импорте файла: {ex.Message}";
                return View("Import");
            }
            return View("Import");
        }

        [HttpGet("GetImportedFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImportedFiles() //Получаю список файлов, которые уже были загружены в БД (Views/Import/GetImportedFiles)
        {
            var files = await fileInfoService.GetAllFileInfos();
            return View(files);
        }

        [HttpGet("ViewFileData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ViewFileData(int id)   //Просмотр информации по id загруженного файла (Views/Import/ViewFileData)
        {
            var data = dataService.GetDataByFileId(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }
    }
}

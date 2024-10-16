namespace WebApplication1.Models
{
    public class ImportViewModel
    {
        public IEnumerable<ClassModel> Classes { get; set; }
        public IEnumerable<NewAccountModel> Accounts { get; set; }
        public IEnumerable<IncomingSaldoModel> IncomingSaldos { get; set; }
        public IEnumerable<TurnoverModel> Turnovers { get; set; }
        public IEnumerable<OutgoingSaldoModel> OutgoingSaldos { get; set; }
    }
}

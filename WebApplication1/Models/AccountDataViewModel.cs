using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class AccountDataViewModel
    {
        public int AccountId { get; set; }
        public string ClassName { get; set; }
        public IncomingSaldoEntity IncomingSaldo { get; set; }
        public TurnoverEntity Turnover { get; set; }
        public OutgoingSaldoEntity OutgoingSaldo { get; set; }
    }
}

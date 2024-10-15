namespace WebApplication1.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Debit {  get; set; }
        public decimal Credit { get; set; }
        public decimal OutgoingSaldoActive { get; set; }
        public decimal OutgoingSaldoPassive { get; set; }
    }
}

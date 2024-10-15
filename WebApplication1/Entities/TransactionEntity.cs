using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Transactions")]
    public class TransactionEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("AccountId")]
        public int AccountId { get; set; }

        [Column("Debit")]
        public decimal Debit { get; set; }

        [Column("Credit")]
        public decimal Credit { get; set; }

        [Column("OutgoingSaldoActive")]
        public decimal OutgoingSaldoActive { get; set; }

        [Column("OutgoingSaldoPassive")]
        public decimal OutgoingSaldoPassive { get; set; }
    }
}

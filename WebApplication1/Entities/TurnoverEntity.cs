using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Turnover")]
    public class TurnoverEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Debit")]
        public decimal Debit { get; set; }

        [Column("Credit")]
        public decimal Credit { get; set; }

        [Column("AccountId")]
        public int AccountId { get; set; }
    }
}

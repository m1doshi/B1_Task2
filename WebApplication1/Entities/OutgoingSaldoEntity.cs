using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Entities
{
    [Table("OutgoingSaldo")]
    public class OutgoingSaldoEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Active")]
        public decimal Active { get; set; }

        [Column("Passive")]
        public decimal Passive { get; set; }

        [Column("IncomingSaldoId")]
        public int IncomingSaldoId { get; set; }

        [Column("TurnoverId")]
        public int TurnoverId { get; set; }
        public IncomingSaldoEntity IncomingSaldo { get; set; }
        public TurnoverEntity Turnover { get; set; }
    }
}

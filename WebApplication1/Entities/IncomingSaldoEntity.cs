using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Entities
{
    [Table("IncomingSaldo")]
    public class IncomingSaldoEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Active")]
        public decimal Active { get; set; }

        [Column("Passive")]
        public decimal Passive { get; set; }

        [Column("AccountId")]
        public int AccountId { get; set; }
        public NewAccountEntity Account { get; set; }
        public ICollection<OutgoingSaldoEntity> OutgoingSaldos { get; set; }
    }
}

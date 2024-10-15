using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Account")]
    public class AccountEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Code")]
        public string Code { get; set; }

        [Column("IncomingSaldoActive")]
        public decimal IncomingSaldoActive { get; set; }

        [Column("IncomingSaldoPassive")]
        public decimal IncomingSaldoPassive { get; set; }

        [Column("ClassId")]
        public int ClassId { get; set; }
    }
}

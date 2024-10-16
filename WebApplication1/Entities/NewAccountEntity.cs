using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Entities
{
    [Table("Account")]
    public class NewAccountEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("ClassId")]
        public int ClassId { get; set; }

        [Column("FileId")]
        public int FileId { get; set; }
        public ClassEntity Class { get; set; }
        public FileInfoEntity File { get; set; }
        public ICollection<IncomingSaldoEntity> IncomingSaldos { get; set; }
        public ICollection<TurnoverEntity> Turnovers { get; set; }
    }
}

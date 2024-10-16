using System.ComponentModel.DataAnnotations.Schema;

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
    }
}

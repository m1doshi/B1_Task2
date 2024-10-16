using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Entities
{
    [Table("FileInfo")]
    public class FileInfoEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("FileName")]
        public string FileName { get; set; }
        public ICollection<NewAccountEntity> Accounts { get; set; }
    }
}

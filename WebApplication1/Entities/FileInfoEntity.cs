using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("FileInfo")]
    public class FileInfoEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("FileName")]
        public string FileName { get; set; }
    }
}

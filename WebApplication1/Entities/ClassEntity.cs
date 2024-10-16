using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Entities
{
    [Table("Class")]
    public class ClassEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        public ICollection<NewAccountEntity> Accounts { get; set; }
    }
}

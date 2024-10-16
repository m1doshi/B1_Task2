using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace WebApplication1.Models
{
    public class NewAccountModel
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int FileId { get; set; }
    }
}

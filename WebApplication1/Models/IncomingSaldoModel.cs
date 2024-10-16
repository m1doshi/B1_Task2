using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class IncomingSaldoModel
    {

        public int Id { get; set; }


        public decimal Active { get; set; }


        public decimal Passive { get; set; }


        public int AccountId { get; set; }
    }
}

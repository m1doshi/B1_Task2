using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OutgoingSaldoModel
    {

        public int Id { get; set; }


        public decimal Active { get; set; }

        public decimal Passive { get; set; }

        public int IncomingSaldoId { get; set; }

        public int TurnoverId { get; set; }
    }
}

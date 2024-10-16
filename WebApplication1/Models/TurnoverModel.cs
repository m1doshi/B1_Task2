using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class TurnoverModel
    {

        public int Id { get; set; }


        public decimal Debit { get; set; }


        public decimal Credit { get; set; }

        public int AccountId { get; set; }
    }
}

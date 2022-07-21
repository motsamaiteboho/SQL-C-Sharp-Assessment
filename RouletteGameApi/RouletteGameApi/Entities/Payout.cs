using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouletteGameApi.Entities
{
    public class Payout
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PayoutAmount{ get; set; }
    }
}


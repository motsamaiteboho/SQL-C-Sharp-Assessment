using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouletteGameApi.Dto
{
    public class PlaceBetDto
    {
        [Required]
        [StringLength(50)]
        public string? TypeOfBet { get; set; }

        [Required]
        public int NumbersOnTheTable { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal BetAmount { get; set; }
    }
}

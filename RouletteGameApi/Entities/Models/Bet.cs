using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Bet
    {
        [Column("BetId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string BetOn { get; set; } = null!;

        public DateTime TimestampUtc { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal  BetValue { get; set; }
        public decimal? BetWinnings { get; set; }
      

        [ForeignKey(nameof(Payout))]
        public Guid? PayoutId { get; set; }
        public  Payout? Payout { get; set; }

        [ForeignKey(nameof(Spin))]
        public Guid? SpinId { get; set; }
        public  Spin? Spin { get; set; } = null!;
    }
}

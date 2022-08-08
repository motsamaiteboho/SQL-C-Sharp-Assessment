using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Payout
    {
        [Column("PayoutId")]
        public Guid Id { get; set; }
        public DateTime TimestampUtc { get; set; }

        public ICollection<Bet>? Bets { get; set; }
    }
}

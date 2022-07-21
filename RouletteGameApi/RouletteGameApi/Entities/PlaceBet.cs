using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouletteGameApi.Entities
{
    public class PlaceBet
    {
        public int Id { get; set; }   
        
        [Required]
        [StringLength(50)]
        public TypeOfBet?  TypeOfBet { get; set; }    

        [Required]
        public int NumbersOnTheTable { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        [Range(0.01,double.MaxValue)]
        public decimal BetAmount { get; set; }
    }
    //The system currently support these types of bets only 
    public enum TypeOfBet
    {
        straightup, split,street,corner,odd,even
    }
}

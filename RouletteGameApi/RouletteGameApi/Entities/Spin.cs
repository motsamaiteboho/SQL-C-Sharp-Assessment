using System.ComponentModel.DataAnnotations;

namespace RouletteGameApi.Entities
{
    public class Spin
    {
        public Guid Id { get; set; }

        [Required]
        [Range(0,37)]
        public int  WinningNumber { get; set; }
    }
}

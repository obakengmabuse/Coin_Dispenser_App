using System.ComponentModel.DataAnnotations;

namespace CoinDispenser.Models
{
    public class CoinLookup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject004.Models
{
    [Table("MiniProject004_Flowers")]
    public class Flower
    {
        public int Id {  get; set; }

        [DisplayName("English name")]
        public string? ENGName { get; set; }

        [DisplayName("German name")]
        public string? GERName { get; set; }

        [DisplayName("Polish name")]
        public string? POLName { get; set; }
    }
}

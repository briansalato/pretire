using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pretire.Data.Models
{
    [Table("TaxBrackets")]
    public class TaxBracketEntity : IEntity
    {
        public int Id { get; set; }
        [Required]
        public decimal LowerBound { get; set; }
        public decimal? UpperBound { get; set; }
        [Required]
        public decimal TaxRate { get; set; }
    }
}
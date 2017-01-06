using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pretire.Data.Models
{
    [Table("GrowthTypes")]
    public class GrowthTypeEntity : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
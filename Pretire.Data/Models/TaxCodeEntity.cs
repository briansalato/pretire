using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Data.Models
{
    [Table("TaxCodes")]
    public class TaxCodeEntity : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<TaxBracketEntity> Brackets { get; set; }
        public bool UsesDeductions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Data.Models
{
    [Table("Salaries")]
    public class SalaryEntity : IEntity
    {
        public int Id { get; set; }

        public SimulationEntity Simulation { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal StartingValue { get; set; }
        [Required]
        public int StartingYear { get; set; }
        public int? EndingYear { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public ICollection<TaxCodeEntity> TaxCodes { get; set; }

        [Required]
        public GrowthTypeEntity GrowthType { get; set; }
        public decimal GrowthRate { get; set;}
    }
}

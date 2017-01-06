using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Data.Models
{
    [Table("Simulations")]
    public class SimulationEntity : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public UserEntity Owner { get; set; }

        public ICollection<SalaryEntity> Salaries { get; set; }
    }
}

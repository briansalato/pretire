using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Data.Models
{
    [Table("Users")]
    public class UserEntity :IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

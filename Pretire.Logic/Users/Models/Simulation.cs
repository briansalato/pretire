using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Users.Models
{
    public class Simulation
    {
        public int Id { get; set; }
        public ICollection<SalaryAsset> Salaries { get; set; }
        //public ICollection<CostItem> Costs { get; set; }
        public ICollection<Asset> Investments { get; set; }
    }
}

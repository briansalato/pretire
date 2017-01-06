using Pretire.Data;
using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretire.Logic.Converters.Entity;

namespace Pretire.Logic.Assets.Managers
{
    public class SalaryManager
    {
        public IEnumerable<SalaryAsset> GetForSimulation(int simulationId)
        {
            using (var dbContext = new PretireDataContext())
            {
                return dbContext.Salaries
                    .Where(salary => salary.Simulation.Id == simulationId)
                    .ToList() // execute db call
                    .Select(salary => salary.ToDomainModel())
                    .ToList();
            }
        }
    }
}

using Pretire.Data;
using Pretire.Data.Models;
using Pretire.Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Pretire.Logic.Converters.Entity;

namespace Pretire.Logic.Users.Managers
{
    public class SimulationManager
    {
        public Simulation GetDefaultSimulation(int userId)
        {
            using (var dbContext = new PretireDataContext())
            {
                return dbContext.Simulations
                    .Include(s => s.Salaries)
                    .FirstOrDefault(sim => sim.Owner.Id == userId && sim.Name == "Default")
                    .ToDomainModel();
            }
        }
    }
}

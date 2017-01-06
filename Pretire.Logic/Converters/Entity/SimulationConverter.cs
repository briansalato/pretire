using Pretire.Data.Models;
using Pretire.Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters.Entity
{
    public static class SimulationConverter
    {
        public static Simulation ToDomainModel(this SimulationEntity entity)
        {
            var domainModel = new Simulation();
            domainModel.Id = entity.Id;
            domainModel.Salaries = entity.Salaries.Select(salaryEntity => salaryEntity.ToDomainModel()).ToList();
            //domainModel.Investments = ;

            return domainModel;
        }
    }
}

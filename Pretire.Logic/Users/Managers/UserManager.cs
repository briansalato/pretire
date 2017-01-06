using Pretire.Data;
using Pretire.Data.Models;
using Pretire.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretire.Logic.Converters.Entity;

namespace Pretire.Logic.Users.Managers
{
    public class UserManager
    {
        public User Add(string email)
        {
            using (var dbContext = new PretireDataContext())
            {
                var userEntity = new UserEntity();
                userEntity.Email = email;
                dbContext.Users.Add(userEntity);

                var defaultSimulation = new SimulationEntity();
                defaultSimulation.Name = "Default"; ;
                defaultSimulation.Owner = userEntity;
                dbContext.Simulations.Add(defaultSimulation);

                dbContext.SaveChanges();

                return userEntity.ToDomainModel();
            }
        }

        public User GetByEmail(string email)
        {
            using (var dbContext = new PretireDataContext())
            {
                return dbContext.Users.FirstOrDefault(user => user.Email == email).ToDomainModel();
            }
        }
    }
}

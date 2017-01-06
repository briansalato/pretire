using Pretire.Data.Models;
using Pretire.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters.Entity
{
    public static class UserConverter
    {
        public static User ToDomainModel(this UserEntity entity)
        {
            var domainModel = new User();
            domainModel.Id = entity.Id;
            return domainModel;
        }
    }
}

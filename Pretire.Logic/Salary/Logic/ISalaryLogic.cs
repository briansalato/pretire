using Pretire.Logic.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Salary.Logic
{
    public interface ISalaryLogic
    {
        ICollection<YearlySalary> GetYearlySalary(ICollection<Person> people, int startYear, int endYear);
        ICollection<YearlyPersonalSalary> GetYearlySalaryPerPerson(ICollection<Person> people, int startYear, int endYear);
    }
}

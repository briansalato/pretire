using System.Collections.Generic;
using Pretire.Models;

namespace Pretire.Logic
{
    public interface IIncomeLogic
    {
        ICollection<IncomeYear> CalculateIncomeYears(Person person, int startYear, int endYear);
        void GetYearlySalaries(ICollection<Person> people, int startingYear, object endingYear);
    }
}
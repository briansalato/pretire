namespace Pretire.Logic.Assets.Calculators
{
    public interface IRetirementContributionCalculator
    {
        decimal CalculateForYear(int year, decimal yearlySalary);
    }
}

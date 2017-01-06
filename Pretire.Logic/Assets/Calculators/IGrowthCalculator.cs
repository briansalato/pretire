namespace Pretire.Logic.Assets.Calculators
{
    public interface IGrowthCalculator
    {
        string Description { get; }
        decimal YearlyGrowthRate { get; }
        decimal CalculateForYear(decimal startingValue, decimal thisYearsContribution);
    }
}
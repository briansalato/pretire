namespace Pretire.Sandbox
{
    public interface IGrowthCalculator
    {
        decimal CalculateForYear(decimal startingValue, decimal thisYearsContribution);
    }
}
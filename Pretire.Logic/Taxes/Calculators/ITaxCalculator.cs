namespace Pretire.Logic.Taxes.Calculators
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal amount, decimal deductions);
    }
}
namespace Pretire.Sandbox
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal amount, decimal deductions);
    }
}
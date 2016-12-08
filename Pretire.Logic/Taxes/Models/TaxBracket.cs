namespace Pretire.Logic.Taxes.Models
{
    public class TaxBracket
    {
        public decimal LowerBound { get; set; }
        public decimal UpperBound { get; set; }
        public decimal TaxRate { get; set; }
    }
}

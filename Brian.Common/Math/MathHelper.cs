namespace Brian.Common.Math
{
    public static class MathHelper
    {
        public static decimal Pow(decimal a, decimal b)
        {
            return (decimal)System.Math.Pow((double)a, (double)b);
        }
    }
}

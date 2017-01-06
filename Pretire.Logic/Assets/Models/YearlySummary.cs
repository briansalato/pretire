﻿namespace Pretire.Logic.Assets.Models
{
    public class YearlySummary
    {
        public int Year { get; set; }
        public decimal StartingValue { get; set; }
        public decimal TaxedAmount { get; set; }
        public decimal ContributionAmount { get; set; }
        public decimal GrowthAmount { get; set; }
        public decimal EndingValue { get; set; }
    }
}
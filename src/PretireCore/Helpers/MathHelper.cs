﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Helpers
{
    public static class MathHelper
    {
        public static decimal Pow(decimal a, decimal b)
        {
            return (decimal)Math.Pow((double)a, (double)b);
        }
    }
}

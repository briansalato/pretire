﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Income
{
    public class ViewSalariesViewModel
    {
        public ICollection<string> Names { get; set; }
        public ICollection<SalaryYear> SalariesByYear { get; set; }
    }
}
using Pretire.Models.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Models
{
    public class Family
    {
        public ICollection<Person> People { get; set; }
        public TaxFilingType TaxFileType { get; set; }
    }
}

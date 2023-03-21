using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GF.DTO
{
    public class ItemResumeDTO
    {
        public string ItemeCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Add { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}

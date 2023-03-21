using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GF.DTO
{
    public class TechnicalResumenDTO
    {
        public string BranchOfficeCode  { get; set; }
        public string BranchOfficeName { get; set; }
        public int Quantity { get; set; }
        public double Add { get; set; }
        public double Avg { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}

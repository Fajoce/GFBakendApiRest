using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GF
{
    public class TechnicalsDTO
    {
        public int TechnicalId { get; set; }
        public string TechnicalFullName { get; set; }
        public string TechnicalCode { get; set; }
        public double TechnicalSalary { get; set; }
        public string BranchOfficeCode { get; set; }
        public string BranchOfficeName { get; set; }
    }
}

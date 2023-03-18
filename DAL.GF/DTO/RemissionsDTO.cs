using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GF.DTO
{
    public class RemissionsDTO
    {
        public int RemissionId { get; set; }
        public DateTime RemissionDate { get; set; }

        public string TechnicalCode { get; set; }
        public string TechnicalFullName { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public int RemissionQuantity { get; set; }
    }
}

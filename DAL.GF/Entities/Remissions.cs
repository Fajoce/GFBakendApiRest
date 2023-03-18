using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.GF.Entities
{
    [Table("Remissions", Schema = "GF")]
    public class Remissions
    {
        [Key]
        public int RemissionId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RemissionDate { get; set; }

        public string TechnicalCode { get; set; }
        [ForeignKey("TechnicalCode")]

        public virtual Technicals Technicals { get; set; }

         public string ItemCode { get; set; }
        [ForeignKey("ItemCode")]

        public virtual Items Items {get;set;}

        [Required]
        public int RemissionQuantity { get; set; }

    }
}

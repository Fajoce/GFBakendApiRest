using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.GF.Entities
{
    [Table("Technicals", Schema="GF")]
    public class Technicals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnicalId { get; set; }
        [Required]
        [MaxLength(30)]
        public string TechnicalFullName { get; set; }
        [Key]
        public string TechnicalCode { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*", ErrorMessage ="No se permiten espacios en blanco ni caracetres especiales")]
        public double TechnicalSalary { get; set; }
        public string BranchOfficeCode { get; set; }
        [ForeignKey("BranchOfficeCode")]

        public virtual BranchOffices BranchOffices { get; set; }

    }
}

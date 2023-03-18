using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.GF.Entities
{
    [Table("BranchOffices", Schema = "GF")]
    public class BranchOffices
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchOfficeId { get; set; }
        [Key]
        public string BranchOfficeCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string BranchOfficeName { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.GF.Entities
{
    [Table("Items", Schema = "GF")]
    public class Items
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Key]
        public string ItemCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string ItemName { get; set; }

    }
}

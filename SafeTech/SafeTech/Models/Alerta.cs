using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeTech.Models
{
    [Table("ALERTA")]
    public class ALERTA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Column("TIPO")]
        [Display(Name = "TIPO")]
        public string TIPO { get; set; }

        [Required]
        [StringLength(300)]
        [Column("DESCRICAO")]
        [Display(Name = "DESCRICAO")]
        public string DESCRICAO { get; set; }

        [Required]
        [Column("DATA_HORA")]
        [Display(Name = "DATA_HORA")]
        public DateTime DATA_HORA { get; set; }

        [ForeignKey("ABRIGO")]
        [Column("ABRIGO_ID")]
        [Display(Name = "ABRIGO_ID")]
        public int ABRIGO_ID { get; set; }

        public ABRIGO ABRIGO { get; set; }
    }
}


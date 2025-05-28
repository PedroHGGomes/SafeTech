using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeTech.Models
{
    [Table("SENSOR")]
    public class SENSOR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Column("TIPO")]
        [Display(Name = "TIPO")]
        public string TIPO { get; set; }

        [Required]
        [Column("ATIVO")]
        [Display(Name = "ATIVO")]
        public bool ATIVO { get; set; }

        [ForeignKey("ABRIGO")]
        [Column("ABRIGO_ID")]
        [Display(Name = "ABRIGO_ID")]
        public int ABRIGO_ID { get; set; }

        public ABRIGO ABRIGO { get; set; }
        public ICollection<LEITURA_SENSOR> LEITURAS { get; set; }
    }
}


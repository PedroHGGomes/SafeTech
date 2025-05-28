using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeTech.Models
{
    [Table("ABRIGO")]
    public class ABRIGO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NOME")]
        [Display(Name = "NOME")]
        public string NOME { get; set; }

        [Required]
        [StringLength(200)]
        [Column("ENDERECO")]
        [Display(Name = "ENDERECO")]
        public string ENDERECO { get; set; }

        [Required]
        [Column("CAPACIDADE")]
        [Display(Name = "CAPACIDADE")]
        public int CAPACIDADE { get; set; }

        [Column("OCUPACAO_ATUAL")]
        [Display(Name = "OCUPACAO_ATUAL")]
        public int OCUPACAO_ATUAL { get; set; }

        public ICollection<SENSOR> SENSORES { get; set; }
        public ICollection<ALERTA> ALERTAS { get; set; }
    }
}


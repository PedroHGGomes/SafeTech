using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeTech.Models
{
    [Table("LEITURA_SENSOR")]
    public class LEITURA_SENSOR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [Column("VALOR")]
        [Display(Name = "VALOR")]
        public double VALOR { get; set; }

        [Required]
        [Column("DATA_HORA")]
        [Display(Name = "DATA_HORA")]
        public DateTime DATA_HORA { get; set; }

        [ForeignKey("SENSOR")]
        [Column("SENSOR_ID")]
        [Display(Name = "SENSOR_ID")]
        public int SENSOR_ID { get; set; }

        public SENSOR SENSOR { get; set; }
    }
}


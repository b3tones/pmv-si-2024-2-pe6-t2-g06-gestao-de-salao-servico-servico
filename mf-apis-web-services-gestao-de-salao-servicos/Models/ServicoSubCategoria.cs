using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    [Table("ServicoSubCategorias")]
    public class ServicoSubCategoria
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public TimeSpan Duracao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public int ServicoCategoriaId { get; set; }
        public ServicoCategoria ServicoCategoria { get; set; }

    }
}

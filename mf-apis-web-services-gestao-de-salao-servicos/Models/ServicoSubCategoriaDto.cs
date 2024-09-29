using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    public class ServicoSubCategoriaDto
    {
        [JsonPropertyOrder(1)]
        public new int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public TimeSpan Duracao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]

        public int ServicoCategoriaId { get; set; }
        public ServicoCategoria ServicoCategoria { get; set; }

    }
}

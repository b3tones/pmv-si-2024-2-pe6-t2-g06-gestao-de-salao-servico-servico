using System.ComponentModel.DataAnnotations;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    public class ServicoCategoriaDto
    {
        public int? Id { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}

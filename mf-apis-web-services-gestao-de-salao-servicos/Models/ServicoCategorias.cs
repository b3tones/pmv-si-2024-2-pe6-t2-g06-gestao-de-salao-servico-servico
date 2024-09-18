using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    [Table("ServicoCategorias")]
    public class ServicoCategoria
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        public ICollection<ServicoSubCategoria> ServicoSubCategorias { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }

    }
}
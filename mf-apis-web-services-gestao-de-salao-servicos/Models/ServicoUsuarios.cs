using mf_apis_web_services_gestao_de_salao_servicos.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    [Table("ServicoUsuarios")]
    public class ServicoUsuarios
    {
        public int ServicoCategoriaId { get; set; }
        public ServicoCategoria ServicoCategoria { get; set; }

        public int UsuariosId { get; set; }
        public Usuario Usuario { get; set; }
    }
}

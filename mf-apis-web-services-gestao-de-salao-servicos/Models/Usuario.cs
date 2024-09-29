using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{

    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [JsonIgnore]
        public string Senha { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(200)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(200)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(200)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(200)]
        public string Cep { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required]
        public GeneroTipo Genero { get; set; }
        [Required]
        public Perfil Perfil { get; set; }

        public ICollection<ServicoUsuarios> Servicos { get; set; }
        public ICollection<ServicoUsuarios> Usuarios { get; set; }

    }

    public enum GeneroTipo
    {
        Masculino,
        Feminino,
        Outro
    }
    public enum Perfil
    {
        [Display(Name = "Usuario")]
        Usuario,
        [Display(Name = "Administrador")]
        Administrador,
        [Display(Name = "Profissional")]
        Profissional
    }

}

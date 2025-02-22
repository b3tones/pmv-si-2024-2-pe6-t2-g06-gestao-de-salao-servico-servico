﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    [Table("ServicoSubCategorias")]
    public class ServicoSubCategoria : LinksHATEOS
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
        [JsonIgnore]
        public int ServicoCategoriaId { get; set; }
        [JsonIgnore]
        public ServicoCategoria ServicoCategoria { get; set; }

        public ICollection<ServicoUsuarios> Usuario { get; set; }

    }
}

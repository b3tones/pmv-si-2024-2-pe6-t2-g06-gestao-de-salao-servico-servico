﻿using System.ComponentModel.DataAnnotations;

namespace mf_apis_web_services_gestao_de_salao_servicos.Models
{
    public class AuthenticateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Application.DTOs
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "Rua é obrigatória")]
        public string Rua { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Número é obrigatório")]
        public string Numero { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Cidade é obrigatória")]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; } = string.Empty;
        [Required(ErrorMessage = "CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP deve estar no formato 00000-000")]
        public string Cep { get; set; } = string.Empty;
    }
}
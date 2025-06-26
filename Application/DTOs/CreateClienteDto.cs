using ClienteApi.Domain;
using System.ComponentModel.DataAnnotations;


namespace ClienteApi.Application.DTOs
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public CreateEnderecoDto? Endereco { get; set; }
    }
}
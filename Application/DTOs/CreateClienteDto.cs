using ClienteApi.Domain;

namespace ClienteApi.Application.DTOs
{
    public class CreateClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public CreateEnderecoDto? Endereco { get; set; }
    }
}
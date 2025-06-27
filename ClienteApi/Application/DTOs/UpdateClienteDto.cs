namespace ClienteApi.Application.DTOs
{
    public class UpdateClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public UpdateEnderecoDto? Endereco { get; set; }
    }
}
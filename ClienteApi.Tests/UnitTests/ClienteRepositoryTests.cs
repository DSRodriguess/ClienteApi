using System;
using System.Linq;
using System.Threading.Tasks;
using ClienteApi.Domain;
using ClienteApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ClienteApi.Tests.UnitTests
{
    public class ClienteRepositoryTests
    {
        private readonly ClienteContext _context;
        private readonly IClienteRepository _repository;

        public ClienteRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ClienteContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ClienteContext(options);
            var mockLogger = new Mock<ILogger<ClienteRepository>>().Object;
            _repository = new ClienteRepository(_context, mockLogger);
        }

        [Fact]
        public async Task GetAllAsync_DeveRetornarListaVazia_QuandoNaoHaClientes()
        {
            var clientes = await _repository.GetAllAsync();

            Assert.NotNull(clientes);
            Assert.Empty(clientes);
        }

        [Fact]
        public async Task AddAsync_DeveSalvarClienteNoBanco()
        {
            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "João Silva",
                Email = "joao@email.com"
            };

            await _repository.AddAsync(cliente);
            var clientes = await _repository.GetAllAsync();

            Assert.NotNull(clientes);
            Assert.Single(clientes);
            Assert.Contains(clientes, c => c.Id == cliente.Id);
        }

        [Fact]
        public async Task GetByIdAsync_DeveRetornarClienteCorreto()
        {
            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Maria Oliveira",
                Email = "maria@email.com"
            };

            await _repository.AddAsync(cliente);

            var result = await _repository.GetByIdAsync(cliente.Id);

            Assert.NotNull(result);
            Assert.Equal(cliente.Id, result.Id);
            Assert.Equal("Maria Oliveira", result.Nome);
        }
    }
}
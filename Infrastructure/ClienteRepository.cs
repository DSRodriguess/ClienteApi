using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClienteApi.Domain;
using Microsoft.Extensions.Logging;

namespace ClienteApi.Infrastructure
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;
        private readonly ILogger<ClienteRepository> _logger;


        public ClienteRepository(ClienteContext context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            _logger.LogDebug("Buscando todos os clientes no banco...");
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            _logger.LogDebug("Buscando cliente por ID: {Id}", id);
            return await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            _logger.LogDebug("Salvando cliente: {Nome}", cliente.Nome);
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _logger.LogDebug("Atualizando cliente: {Id}", cliente.Id);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogDebug("Removendo cliente: {Id}", id);
            var cliente = await GetByIdAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
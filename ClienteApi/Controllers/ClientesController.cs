using Microsoft.AspNetCore.Mvc;
using ClienteApi.Application.DTOs;
using ClienteApi.Domain;
using AutoMapper;
using System.Net;
using Microsoft.Extensions.Logging;


namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientesController> _logger;


        public ClientesController(IClienteRepository repository, IMapper mapper, ILogger<ClientesController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Buscando todos os clientes...");
            var clientes = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ClienteDto>>(clientes);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            var dto = _mapper.Map<ClienteDto>(cliente);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Dados inválidos recebidos no POST /clientes");
                return BadRequest(ModelState); 
            }
            _logger.LogInformation("Criando novo cliente: {Nome}", dto.Nome);

            var cliente = _mapper.Map<Cliente>(dto);
            await _repository.AddAsync(cliente);

            _logger.LogInformation("Cliente criado com sucesso: {Id}", cliente.Id);

            var resultDto = _mapper.Map<ClienteDto>(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var cliente = _mapper.Map(dto, existing);
            await _repository.UpdateAsync(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
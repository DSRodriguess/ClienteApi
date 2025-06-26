using Microsoft.AspNetCore.Mvc;
using ClienteApi.Application.DTOs;
using ClienteApi.Domain;
using AutoMapper;
using System.Net;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
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
            var cliente = _mapper.Map<Cliente>(dto);
            await _repository.AddAsync(cliente);

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
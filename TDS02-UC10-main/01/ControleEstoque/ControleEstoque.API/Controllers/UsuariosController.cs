using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControleEstoque.API.Services;
using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await _service.ListarTodosUsuariosAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _service.BuscarUsuarioPorId(id);
            if (usuario == null) return NotFound("Usuario não encontrado para o id informado");
            return Ok(usuario);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var usuario = await _service.BuscarUsuarioPorEmail(email);
            if (usuario == null) return NotFound("Usuario não encontrado para o email informado");
            return Ok(usuario);
        }
        [HttpPost("registrar-cliente")]
        public async Task<IActionResult> Registrar([FromBody] CriarClienteDto dto)
        {
            var novoCliente = await _service.RegistrarCliente(dto);
            return Ok(novoCliente);
        }
        [HttpPost("registrar-caixa")]
        public async Task<IActionResult> Registrar([FromBody] CriarCaixaDto dto)
        {
            var novoCaixa = await _service.RegistrarCaixa(dto);
            return Ok(novoCaixa);
        }
        [HttpPost("registrar-gerente")]
        public async Task<IActionResult> Registrar([FromBody] CriarGerenteDto dto)
        {
            var novoGerente = await _service.RegistrarGerente(dto);
            return Ok(novoGerente);
        }
    }
}


using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioDto?> BuscarUsuarioPorEmail(string email)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return null;
            }

            return MapearParaDto(usuario);
        }
        public async Task<UsuarioDto?> BuscarUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return null;
            }

            return MapearParaDto(usuario);
        }
        public async Task<IEnumerable<UsuarioDto>> ListarTodosUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios.Select(MapearParaDto);
        }

        private static UsuarioDto MapearParaDto(Usuario usuario)
        {
            var dto = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };

            if (usuario is Cliente cliente)
            {
                dto.CPF = cliente.CPF;

                if (usuario is Caixa caixa)
                {
                    dto.Turno = caixa.Turno;
                }

                if (usuario is Gerente gerente)
                {
                    dto.Setor = gerente.Setor;
                }

            }
            return dto;

        }

        public async Task<UsuarioDto> RegistrarCliente(CriarClienteDto dto)
        {
            var cliente = new Cliente
            {
                Email = dto.Email,
                Nome = dto.Nome,
                SenhaHash = dto.Senha,
                CPF = dto.CPF,
                Perfil = PerfilUsuario.Cliente
            };
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return MapearParaDto(cliente);
        }

 
        public async Task<UsuarioDto> RegistrarCaixa(CriarCaixaDto dto)
        {
            var caixa = new Caixa()
            {
                Email = dto.Email,
                Nome = dto.Nome,
                SenhaHash = dto.Senha,
                Turno = dto.Turno,
                Perfil = PerfilUsuario.Caixa
            };
            _context.Add(caixa);
            await _context.SaveChangesAsync();
            return MapearParaDto(caixa);
        }

        public async Task<UsuarioDto> RegistrarGerente(CriarGerenteDto dto)
        {
            var gerente = new Gerente()
            {
                Email = dto.Email,
                Nome = dto.Nome,
                SenhaHash = dto.Senha,
                Setor = dto.Setor,
                Perfil = PerfilUsuario.Gerente
            };
            _context.Add(gerente);
            await _context.SaveChangesAsync();
            return MapearParaDto(gerente);
        }
    }
}

using ControleEstoque.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace ControleEstoque.API.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PerfilUsuario Perfil { get; set; }

        public string? Turno { get; set; }
        public string? CPF { get; set; }
        public string? Setor { get; set; }

    }
    public class CriarClienteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
    }

    public class CriarCaixaDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Turno { get; set; }
    }
    public class CriarGerenteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Setor { get; set; }
    }

}
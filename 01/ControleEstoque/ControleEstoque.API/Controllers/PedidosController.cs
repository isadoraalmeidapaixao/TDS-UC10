using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido(int id)
        {
            var pedido = await _pedidoService.ObterPedidoComDetalhesAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoDto pedido)
        {
            /* 
            List<ItemPedido> itensPedido = new List<ItemPedido>();
            foreach (var item in pedido.Itens)
            {
               var novoItem = new ItemPedido
                {
                    Id = item.ProdutoId,
                   Quantidade = item.Quantidade
               };
                listaItens.Add(novoItem);
            }
            */

            var itensPedido = pedido.Itens.Select(i => new ItemPedido
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade
            }).ToList();

            var novoPedido = await _pedidoService.CriarPedidoAsync(pedido.ClienteId, null);
            return Ok(novoPedido);
        }
    }
}

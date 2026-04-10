

namespace ControleEstoque.API.DTOs
{
    public class DetalhesPedidoDto
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }

        public string Status { get; set; }
        public int? ClienteId { get; set; }
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
        public List<DetalhesItemPedidoDto> Itens {get; set;}
    }
    public class DetalhesItemPedidoDto
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int? ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
    }
}

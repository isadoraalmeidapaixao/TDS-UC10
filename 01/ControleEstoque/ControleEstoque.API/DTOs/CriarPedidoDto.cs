namespace ControleEstoque.API.DTOs
{
    public class CriarPedidoDto
    {
        public int ClienteId { get; set; }
        public List<CriarItemPedidoDto> Itens { get; set; }
    }

    public class CriarItemPedidoDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        //não pedimos o preço, back end busca no banco
    }

}

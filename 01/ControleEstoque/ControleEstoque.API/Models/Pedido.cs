using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.API.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        [Required, StringLength(20)]
        public string Status { get; set; }
        public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}

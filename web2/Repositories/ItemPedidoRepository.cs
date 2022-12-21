using web2.Models;

namespace web2.Pepositories;

public interface IItemPedidoRepository
{ }
public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
{
  public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
  {
  }
}
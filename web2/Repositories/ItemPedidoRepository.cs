using web2.Models;

namespace web2.Pepositories;

public interface IItemPedidoRepository
{
  ItemPedido? GetItemPedido(int ItemPedidoId);
  void RemoveItemPedido(int ItemPedidoId);
}
public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
{
  public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
  {
  }

  public ItemPedido? GetItemPedido(int ItemPedidoId)
  {
    return _dbSet
    .Where(ip => ip.Id == ItemPedidoId)
    .SingleOrDefault();
  }

  public void RemoveItemPedido(int ItemPedidoId)
  {
    _dbSet.Remove(GetItemPedido(ItemPedidoId));

  }
}
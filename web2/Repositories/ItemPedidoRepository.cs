using web2.Models;

namespace web2.Pepositories;

public interface IItemPedidoRepository
{
  void UpdateQuantidade(ItemPedido itemPedido);
}
public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
{
  public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
  {
  }

  public void UpdateQuantidade(ItemPedido itemPedido)
  {
    var itemPedidoDB =
    _dbSet
      .Where(ip => ip.Id == itemPedido.Id)
      .SingleOrDefault();
    System.Console.WriteLine($"Item: {(itemPedidoDB == null)}");
    if (itemPedidoDB != null)
    {
      System.Console.WriteLine($"Item quantidade: {itemPedido.Quantidade} ");
      itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
      _contexto.SaveChanges();
    }
  }
}
using web2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace web2.Pepositories;
public interface IPedidoRepository
{
  void AddItem(string codigo);
  Pedido GetPedido();
}

public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
{

  private readonly IHttpContextAccessor _contextAccessor;
  public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
  {
    this._contextAccessor = contextAccessor;
  }

  public void AddItem(string codigo)
  {
    //verifica se o produto existe
    var produto = _contexto.Set<Produto>().Where(p => p.Codigo == codigo).FirstOrDefault();

    if (produto == null) throw new ArgumentException("Produto não encontrado");

    var pedido = GetPedido();
    var itemPedido = _contexto.Set<ItemPedido>()
      .Where(i => i.Produto.Codigo == codigo && i.Pedido.Id == pedido.Id)
      .SingleOrDefault();

    if (itemPedido == null)
    {
      itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
      _contexto.Set<ItemPedido>()
        .Add(itemPedido);

      _contexto.SaveChanges();
    }

  }

  //informa a view qual o peido da sessão
  public Pedido GetPedido()
  {
    var pedidoId = GetPedidoId();
    //fazendo uma consulta que incluí dados de outros modelos relacionados
    var pedido = _dbSet
      .Include(p => p.Itens)
        .ThenInclude(i => i.Produto)
      .Where(p => p.Id == pedidoId)
      .SingleOrDefault();

    if (pedido == null)
    {
      pedido = new Pedido();
      _dbSet.Add(pedido);
      _contexto.SaveChanges();
      SetPedidoId(pedido.Id);
    }

    return pedido;
  }

  //Ler o pedido da sessão
  private int? GetPedidoId()
  {
    return _contextAccessor.HttpContext?.Session.GetInt32("pedidoId");
  }
  //Gravar o pedido da sessão
  private void SetPedidoId(int pedidoId)
  {
    _contextAccessor.HttpContext?.Session.SetInt32("pedidoId", pedidoId);
  }
}
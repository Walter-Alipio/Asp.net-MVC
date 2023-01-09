using web2.Models.ViewModels;

namespace web2.Models;

public class UpdateQuantidadeResponse
{
  public ItemPedido? ItemPedido { get; }
  public CarrinhoViewModel? CarrinhoViewModel { get; }
  public UpdateQuantidadeResponse(ItemPedido itemPeidido, CarrinhoViewModel carrinhoViewModel)
  {
    ItemPedido = itemPeidido;
    CarrinhoViewModel = carrinhoViewModel;
  }
}
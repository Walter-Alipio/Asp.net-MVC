using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web2.Models;
using web2.Pepositories;

namespace web2.Controllers;

public class PedidoController : Controller
{
  private readonly ILogger<PedidoController> _logger;
  private readonly IProdutoRepository _produtoRepository;
  private readonly IPedidoRepository _pedidoRepository;
  private readonly IItemPedidoRepository _itemRepository;
  public PedidoController(ILogger<PedidoController> logger, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemRepository)
  {
    _logger = logger;
    _produtoRepository = produtoRepository;
    _pedidoRepository = pedidoRepository;
    _itemRepository = itemRepository;
  }

  public IActionResult Carrossel()
  {
    return View(_produtoRepository.GetProdutos());
  }
  public IActionResult Carrinho(string codigo)
  {
    if (!String.IsNullOrEmpty(codigo))
    {
      _pedidoRepository.AddItem(codigo);
    }

    Pedido pedido = _pedidoRepository.GetPedido();
    return View(pedido.Itens);
  }
  public IActionResult Cadastro()
  {
    return View();
  }
  public IActionResult Resumo()
  {
    Pedido pedido = _pedidoRepository.GetPedido();
    return View(pedido);
  }

  [HttpPost]
  public void UpdateQuantidade([FromBody] ItemPedido itemPedido)
  {
    System.Console.WriteLine($"Id: {itemPedido.Id}, Quantidade: {itemPedido.Quantidade}");
    _itemRepository.UpdateQuantidade(itemPedido);
  }
}
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web2.Models;
using web2.Models.ViewModels;
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

    var itens = _pedidoRepository.GetPedido().Itens;
    CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
    return View(carrinhoViewModel);

  }
  public IActionResult Cadastro()
  {
    var pedido = _pedidoRepository.GetPedido();

    if (pedido == null) return RedirectToAction("Carrossel");

    return View(pedido.Cadastro);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Resumo(Cadastro cadastro)
  {
    if (ModelState.IsValid) return View(_pedidoRepository.UpdateCadastro(cadastro));

    return RedirectToAction("Cadastro");
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public UpdateQuantidadeResponse UpdateQuantidade([FromBody] ItemPedido itemPedido)
  {
    System.Console.WriteLine($"Id: {itemPedido.Id}, Quantidade: {itemPedido.Quantidade}");
    return _pedidoRepository.UpdateQuantidade(itemPedido);
  }
}
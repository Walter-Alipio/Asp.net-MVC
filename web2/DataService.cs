using System.Text.Json;
using web2.Models;
using web2.Pepositories;

public class DataService : IDataService
{
  private readonly ApplicationContext _contexto;
  private readonly IProdutoRepository _produtoRepository;



  public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
  {
    _contexto = contexto;
    _produtoRepository = produtoRepository;
  }

  public void InicializaDB()
  {
    _contexto.Database.EnsureCreated();

    var livros = GetLivros();

    if (livros == null)
    {
      throw new NullReferenceException();
    }

    _produtoRepository.SaveProdutos(livros);
  }

  private static List<Livro>? GetLivros()
  {
    var json = File.ReadAllText("livros.json");
    //Usando JsonSerializer no lugar de JsonConvert
    return JsonSerializer.Deserialize<List<Livro>>(json);
  }


}

public class Livro
{
  public string Codigo { get; set; } = string.Empty;
  public string Nome { get; set; } = string.Empty;
  public decimal Preco { get; set; }
}
using Microsoft.EntityFrameworkCore;
using web2.Models;

namespace web2.Pepositories;


public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
  public ProdutoRepository(ApplicationContext contexto) : base(contexto)
  {
  }

  public IList<Produto> GetProdutos()
  {
    return _contexto.Set<Produto>().ToList();
  }

  public void SaveProdutos(List<Livro> livros)
  {
    foreach (var livro in livros)
    {
      if (!_dbSet.Where(p => p.Codigo == livro.Codigo).Any())
        _dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
    }
    //gravando no banco de dados
    _contexto.SaveChanges();
  }
}
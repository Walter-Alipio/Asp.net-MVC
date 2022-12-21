
using web2.Models;

namespace web2.Pepositories;
public interface IProdutoRepository
{
  void SaveProdutos(List<Livro> livros);
  IList<Produto> GetProdutos();
}
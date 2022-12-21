using web2.Models;

namespace web2.Pepositories;

public interface ICadastroRepository { }
public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
{
  public CadastroRepository(ApplicationContext contexto) : base(contexto)
  {
  }
}
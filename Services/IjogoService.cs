using System;
using System.Collections.Generic;
using System.Linq;
using Sytem.Threading.Tasks;

namespace ApiCatalogojogos.Services

{
	public interface IjogoService
	{
	  Task<List<JogoViewModel>> Obter( int pagina, int quantidade);

	  Task<JogoViewModel> Obter(Guid id);

	  Task<JogoViewModel> Inserir(JogoInputModel jogo);

	  Task<Atualizar(Guid id, JogoInputModel jogo);

	  Task Atualizar(Guid id, double preco);
    
	  Task Remover(Guid id);

	}






}
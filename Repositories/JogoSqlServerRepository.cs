using ApiCatalogoJogos.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collectinos.Generic;
using System.Data.SqlClient;
using Sytem.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories : IJogoRepository
{
	private readonly SqlConnection sqlConnection;

	public class JogoSqlServerRepository(IConfiguration configuration)
	{
		sqlConnection = new SqlConnection(configuration.GetConnetionString("Default"));

	}

	public async Task<List<Jogos>> Obter (Int pagina, int quantidade)
	{
		var jogos = new List<Jogo>();

		var comando = $"select * from Jogos order by id offset {((pagina -1) * quantidade)} rows fetch next {quantidade} rows only";

		await sqlConnection.OpenAsync():
		SqlCommand sqlCommand new SqlCommand(comando, sqlConnection);
		SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

		while(sqlDataReader.Read())
		{
			jogos.Add(new Jogo
			{
				I = (Guid)sqlReader["Id"},
				Nome = (string)sqlDataReader["Nome"],
				Produtora = (string)sqlDataReader["Produtora"],
				Preco = (double)sqlDataReader["Preco"]
			});
		}
		
		await sqlConnection.CloseAsync();
		
 		return jogos;

	  }
		
	  public async Task<Jogo> Obter(Guid id)
	  {

		Jogo jogo = null;
		
		var comando = $"select * from Jogos where Id ='{id}'";
		
		await sqlConnection.OpenAsync():
		SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
		SqlDataReader sqlDataReader = await sqlCommand.ExecuteREaderAsync();

		while(sqlDataReader.Read())
		{
			jogo = new Jogo
			{
				Id = (Guid)sqlDataReader["Id"],
				Nome =(string)sqlDataReader["Nome"],
				Produtora = (string)sqlDataReader["Produtora"],
				Preco = (double)sqlDataReader["Preco"]
			};

		}
		
		await sqlConnection.CloseAsync();

		return jogos;


	    }
	    

 	    public async Task Inserir(Jogo jogo)
            {
		var command = $"insert Jogos(Id, Nome, Produtora, Preco) values('{jogo.Id}', '{jogo.Produtora}', {jogo.Preco.ToString().Replace(",", ".")})";

		await sqlConnection.OpenAsync();
		SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		await sqlConnection.CloseAsync();

	    };

	     public async Task Atualizar(Jogo jogo)
	     {
		var comando =$"update Jogos set Nome = '{jogo.Nome}', Produtora = '{jogo.Produtora}', Preco = {jogo.Preco.ToString().Replace(",", ".")} where Id = '{jogo.Id}'";
		
		await sqlConnection.OpenAsync();
		SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		await sqlConnection.CloseAsync();
				
	     }

	     public async Task Remover(Guid id)
	     {
		var comando = $"delete from Jogos where Id = '{id}'";
		
		await sqlConnection.OpenAsync();
		SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		await sqlConnection.CloseAsync();

	     }

	     public void Dispose()
	    {
		sqlConnection?.Close();
		sqlConnection?.Dispose();
	    }


}
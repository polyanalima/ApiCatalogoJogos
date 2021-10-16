using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel

	public class JogoInputModel
	{
		
	[Required]
	[StringLength(100, MininumLength = 3, ErrorMessage = " O nome do jogo deve conter entre 3 e 100 caracteres")]

	public string Nome {get; set; }
	[Required]
	[StringLength(100, MininumLength = 1, ErrorMessege = "O nome da produtora deve conter entre 3 e 100 caracteres")]

	public string Produtora {get; set; }
	[Required]
	[Range(1, 1000, ErrorMessege = "O preço de ser mínimo 1 real e no máximo 1000 reais ")] 

	public double Preco{get ; set; }

	}
using ProjetoDIO.Classes;
using ProjetoDIO.Enum;
using System;
using System.Runtime;

namespace ProjetoDIO
{
    class Program
    {
	
		static SerieRepositorio _serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio _filmeRepositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeriesEFilmes();
						break;
					case "2":
						InserirSerieFilme();
						break;
					case "3":
						AtualizarSerieFilme();
						break;
					case "4":
						ExcluirConteudo();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
                Console.WriteLine();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ListarSeriesEFilmes()
		{
			Console.WriteLine("Listar séries e Filmes");

			var lista = _serieRepositorio.Lista();
			var lista2 = _filmeRepositorio.Lista();

			if (lista.Count == 0 && lista2.Count == 0)
			{
				Console.WriteLine("Nenhum conteudo cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.RetornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
            Console.WriteLine();

			foreach (var filme in lista2)
			{
				var excluido = filme.RetornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", filme.RetornaId(), filme.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirSerieFilme()
		{


			Console.WriteLine("Inserir novo Conteudo");
            Console.WriteLine();

			Console.WriteLine("Filme (1) Serie(2)");
			int conteudo = 0;
			do
			{
				conteudo = int.Parse(Console.ReadLine());
				
			}while(conteudo<1 && conteudo>2);
            Console.WriteLine();

			foreach (int i in System.Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.Write("Digite o Título : ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início : ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição : ");
				string entradaDescricao = Console.ReadLine();

				if (conteudo == 2)
				{
					Serie novaSerie = new Serie(id: _serieRepositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

					_serieRepositorio.Insere(novaSerie);
				}
				if (conteudo == 1)
				{
					Filme novaFilme = new Filme(id: _serieRepositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

					_filmeRepositorio.Insere(novaFilme);
				}


		
		}

		private static void AtualizarSerieFilme()
		{
			Console.Write("Digite o id : ");
			int indice = int.Parse(Console.ReadLine());

            Console.WriteLine("E um Filme(1) ou Serie(2) que voce vai editar ?");
			int conteudo;
			do
			{
				conteudo = int.Parse(Console.ReadLine());
				
			} while (conteudo < 1 && conteudo > 2);

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título : ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início : ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição : ");
			string entradaDescricao = Console.ReadLine();

			if(conteudo == 2)
            {
				Serie atualizaSerie = new Serie(id: indice,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				_serieRepositorio.Atualiza(indice, atualizaSerie);
			}
			if (conteudo == 1)
			{
				Filme atualizaFilme = new Filme(id: indice,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				_filmeRepositorio.Atualiza(indice, atualizaFilme);
			}

		}

		private static void ExcluirConteudo()
		{
			Console.Write("Digite o id : ");
			int indice = int.Parse(Console.ReadLine());
			Console.WriteLine("Filme (1) Serie(2)");
			int conteudo;
			do
			{
				conteudo = int.Parse(Console.ReadLine());

			} while (conteudo < 1 && conteudo > 2);

			if(conteudo == 2)
            {
				_serieRepositorio.Exclui(indice);
			}
			if(conteudo == 1)
            {
				_filmeRepositorio.Exclui(indice);
            }
			
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id e se e FIlme ou Serie: ");
			int indice = int.Parse(Console.ReadLine());
			Console.WriteLine("Filme (1) Serie(2)");
			int conteudo;
			do
			{
				conteudo = int.Parse(Console.ReadLine());

			} while (conteudo < 1 && conteudo > 2);

			if(conteudo == 2)
            {
				var serie = _serieRepositorio.RetornaPorId(indice);

				Console.WriteLine(serie);
			}
			if (conteudo == 1)
			{
				var filme = _filmeRepositorio.RetornaPorId(indice);

				Console.WriteLine(filme);
			}

		}


		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();

			Console.WriteLine("1- Listar conteudos");
			Console.WriteLine("2- Inserir novo conteudo");
			Console.WriteLine("3- Atualizar Filme ou Serie");
			Console.WriteLine("4- Excluir conteudo");
			Console.WriteLine("5- Visualizar conteudo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}

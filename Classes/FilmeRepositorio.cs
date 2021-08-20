using ProjetoDIO.Interfaces;
using System.Collections.Generic;

namespace ProjetoDIO.Classes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
		private readonly List<Filme> listaFilme = new();
		public void Atualiza(int id, Filme objeto)
		{
			listaFilme[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFilme[id].Excluir();
		}

		public void Insere(Filme objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filme RetornaPorId(int id)
		{
			return listaFilme[id];
		}
	}
}

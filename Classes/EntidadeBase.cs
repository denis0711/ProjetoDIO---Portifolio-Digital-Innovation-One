using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDIO.Classes
{
    public abstract class  EntidadeBase
    {
        public int Id { get; set; }
		public string Titulo { get; set; }

		public bool Excluido { get; set; }


		public string RetornaTitulo()
		{
			return Titulo;
		}

		public int RetornaId()
		{
			return Id;
		}
		public bool RetornaExcluido()
		{
			return Excluido;
		}
		public void Excluir()
		{
			Excluido = true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
	public class Aresta
	{
		public Vertice Origem { get; set; }
		public Vertice Destino { get; set; }
		public string Nome { get; set; }

		public Aresta(Vertice origem, Vertice destino, string nome )
		{
			this.Origem = origem;
			this.Destino = destino;
			this.Nome = nome;
		}
	}
}

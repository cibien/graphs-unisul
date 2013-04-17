using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
	public class Aresta
	{
		/// <summary>
		/// O vértice de origem da aresta.
		/// </summary>
		public Vertice Origem { get; set; }

		/// <summary>
		/// O vértice de destino da aresta.
		/// </summary>
		public Vertice Destino { get; set; }

		/// <summary>
		/// O nome da aresta.
		/// </summary>
		public string Nome { get; set; }

		/// <summary>
		/// O peso/custo da aresta.
		/// </summary>
		public int Peso { get; set; }

		/// <summary>
		/// Construtor padrão.
		/// </summary>
		/// <param name="origem">Define o vértice de origem.</param>
		/// <param name="destino">Define o vértice de destino.</param>
		/// <param name="peso">Define o peso/custo da aresta.</param>
		/// <param name="nome">Define o nome da aresta.</param>
		public Aresta( Vertice origem, Vertice destino, int peso, string nome )
		{
			this.Origem = origem;
			this.Destino = destino;
			this.Peso = peso;
			this.Nome = nome;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
	public class Vertice
	{
		/// <summary>
		/// Define o nome do vértice.
		/// </summary>
		public string Nome { get; set; }

		/// <summary>
		/// Define o caminho até este vértice.
		/// </summary>
		public Vertice Caminho { get; set; }

		/// <summary>
		/// Define a distância do vértice.
		/// </summary>
		public int Distancia { get; set; }

		/// <summary>
		/// Construtor padrão
		/// </summary>
		/// <param name="nome">O nome do vértice.</param>
		public Vertice( string nome )
		{
			Nome = nome;
		}

		/// <summary>
		/// Mostra o nome do vértice.
		/// </summary>
		/// <returns>O nome do vértice.</returns>
		public override string ToString( )
		{
			return this.Nome;
		}
	}
}

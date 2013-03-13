using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
	public class Grafo
	{
		/// <summary>
		/// Contêm a lista de vértices do grafo.
		/// </summary>
		public List<Vertice> Vertices { get; set; }

		/// <summary>
		/// Contêm a lista de aresta do grafo.
		/// </summary>
		public List<Aresta> Arestas { get; set; }

		/// <summary>
		/// Define se o grafo é dígrafo (as arestas possuem direção) ou não.
		/// </summary>
		public bool isDigrafo { get; set; }

		/// <summary>
		/// Define a lista de adjacência da aresta.
		/// </summary>
		public List<string> ListaAdjacencia { get; set; }

		/// <summary>
		/// Construtor do grafo
		/// </summary>
		/// <param name="digrafo">Define se o grafo é dígrafo.</param>
		public Grafo( bool digrafo )
		{
			this.isDigrafo = digrafo;

			this.Vertices = new List<Vertice>( );
			this.Arestas = new List<Aresta>( );
		}

		/// <summary>
		/// Adiciona um vértice à lista de vértices do grafo.
		/// </summary>
		/// <param name="nome">O nome do vértice.</param>
		/// <returns>O Vértice criado.</returns>
		public Vertice AddVertice( string nome )
		{
			Vertice m_vertice = new Vertice( nome );
			Vertices.Add( m_vertice );

			return m_vertice;
		}

		/// <summary>
		/// Adiciona uma aresta à lista de arestas do grafo.
		/// </summary>
		/// <param name="origem">O Vértice de origem.</param>
		/// <param name="destino">O Vértice de destino.</param>
		/// <returns>A aresta criada.</returns>
		public Aresta AddAresta( Vertice origem, Vertice destino )
		{
			Aresta m_aresta = new Aresta( origem, destino );
			Arestas.Add( m_aresta );

			return m_aresta;
		}
	}
}

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
		/// Contador de arestas real.
		/// </summary>
		public int CountArestas
		{
			get
			{
				int i = Arestas.GroupBy( a => a.Nome ).Count( );
				return i;
			}
		}

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
		public bool isDirigido { get; set; }

		public Vertice VerticeMaiorGrau
		{
			get
			{
				Dictionary<Vertice, int> graus = new Dictionary<Vertice, int>( );

				foreach( Vertice vertice in this.Vertices )
				{
					graus.Add( vertice, 0 );

					foreach( Aresta aresta in this.Arestas )
					{
						if( aresta.Destino.Nome == vertice.Nome || aresta.Origem.Nome == vertice.Nome )
							graus[ vertice ] += 1;
					}
				}

				return ( Vertice )graus.Where( a => a.Value == graus.Values.Max( ) ).Select( a => a.Key );
			}
		}

		/// <summary>
		/// Lista de vértices e seus adjacentes contendo o custo.
		/// </summary>
		public List<Tuple<Vertice, double>> ProximosVertices { get; set; }

		/// <summary>
		/// Construtor do grafo
		/// </summary>
		/// <param name="dirigido">Define se o grafo é dígrafo.</param>
		public Grafo( bool dirigido )
		{
			this.isDirigido = dirigido;

			this.Vertices = new List<Vertice>( );
			this.Arestas = new List<Aresta>( );
			this.ProximosVertices = new List<Tuple<Vertice, double>>( );
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
		/// <param name="peso">O peso/custo da aresta.</param>
		/// <param name="nome">O nome da aresta.</param>
		/// <returns>A aresta criada.</returns>
		public Aresta AddAresta( Vertice origem, Vertice destino, int peso, string nome )
		{
			Aresta m_aresta = new Aresta( origem, destino, peso, nome );
			Arestas.Add( m_aresta );

			return m_aresta;
		}
	}
}

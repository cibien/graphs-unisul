using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Graphs.Class
{
	public static class Representacoes
	{
		/// <summary>
		/// Calcula o menor caminho p
		/// </summary>
		/// <param name="grafo"></param>
		/// <param name="origem"></param>
		/// <param name="destino"></param>
		/// <param name="caminhoPercorrido"></param>
		/// <returns></returns>
		public static double CalculaMenorCaminho( Grafo grafo, Vertice origem, Vertice destino, List<Vertice> caminhoPercorrido )
		{
			double menor = Double.MaxValue;
			double custo = 0;

			caminhoPercorrido.Add( origem );

			if( origem.Nome == destino.Nome )
				return custo;

			List<Vertice> caminhoAnterior = new List<Vertice>( caminhoPercorrido );
			List<Vertice> caminho = null;

			foreach( Vertice proxVertice in GetAdjacentes( grafo, origem ) )
			{
				caminho = new List<Vertice>( caminhoAnterior );
				custo = Double.MaxValue;

				if( !caminho.Exists( a => a.Nome == proxVertice.Nome ) )
					custo = 1 + CalculaMenorCaminho( grafo, proxVertice, destino, caminho );
			}

			if( custo < menor )
			{
				menor = custo;

				caminhoPercorrido.Clear( );
				caminho.ForEach( a =>
				{

					caminhoPercorrido.Add( a );
				} );
			}

			return menor;
		}

		/// <summary>
		/// Gera a matriz de incidêcia do grafo.
		/// </summary>
		/// <param name="grafo">O grafo a ser analisado.</param>
		/// <returns>A matriz de incidência.</returns>
		public static int[ , ] GetMatrizIncidencia( Grafo grafo )
		{
			int countVertices = grafo.Vertices.Count;
			int countArestas = grafo.CountArestas;
			var matrixIncidencia = new int[ countVertices, countArestas ]; //para colocar o nome dos vértices
			List<Aresta> arestas = grafo.Arestas.OrderBy( a => a.Nome ).ToList( );
			List<Vertice> vertices = grafo.Vertices.OrderBy( a => a.Nome ).ToList( );

			for( int i = 0; i < countVertices; i++ )
			{
				for( int j = 0; j < countArestas; j++ )
				{
					if( grafo.isDirigido )
					{
						if( arestas[ j ].Origem.Nome == vertices[ i ].Nome )
							matrixIncidencia[ i, j ] = 1;
						else if( arestas[ j ].Destino.Nome == vertices[ i ].Nome )
							matrixIncidencia[ i, j ] = -1;
						else
							matrixIncidencia[ i, j ] = 0;
					}
					else
					{
						matrixIncidencia[ i, j ] = ( vertices[ i ].Nome == arestas[ j ].Origem.Nome ||
											    vertices[ i ].Nome == arestas[ j ].Destino.Nome ) ? 1 : 0;
					}
				}
			}

			return matrixIncidencia;
		}

		/// <summary>
		/// Monta a matrix de adjacência do Grafo.
		/// </summary>
		/// <param name="grafo">O grafo a ser analisado.</param>
		/// <returns>A matriz de adjacência do grafo.</returns>
		public static int[ , ] GetMatrizAdjacencia( Grafo grafo )
		{
			var countVertices = grafo.Vertices.Count;
			var matrixAdj = new int[ countVertices, countVertices ];

			foreach( Aresta aresta in grafo.Arestas.OrderBy( a => a.Origem.Nome ) )
			{
				Vertice origem = grafo.Vertices.Where( a => a.Nome == aresta.Origem.Nome ).First( );
				var i = grafo.Vertices.IndexOf( origem );

				Vertice destino = grafo.Vertices.Where( a => a.Nome == aresta.Destino.Nome ).First( );
				var j = grafo.Vertices.IndexOf( destino );

				if( i < 0 || j < 0 )
					continue;

				matrixAdj[ i, j ] = 1;

				if( !grafo.isDirigido )
					matrixAdj[ j, i ] = 1;
			}

			return matrixAdj;
		}

		/// <summary>
		/// Monta a lista de adjacência do grafo.
		/// </summary>
		/// <param name="grafo">O grafo a ser verificado.</param>
		/// <returns>Para cada vértice do grafo será criada uma lista de vértices adjacentes.</returns>
		public static List<List<Vertice>> GetListaAdjacencia( Grafo grafo )
		{
			List<List<Vertice>> m_lista = new List<List<Vertice>>( );

			foreach( Vertice vertice in grafo.Vertices.OrderBy( a => a.Nome ) )
			{
				List<Vertice> m_listaVertices = GetAdjacentes( grafo, vertice );

				m_lista.Add( new List<Vertice>( ) );

				foreach( Vertice verticeAdj in m_listaVertices )
				{
					m_lista[ Convert.ToInt32( vertice.Nome ) - 1 ].Add( new Vertice( verticeAdj.Nome ) );
				}
			}

			return m_lista;
		}

		/// <summary>
		/// Obtem a lista de arestas para o grafo
		/// </summary>
		/// <param name="grafo"></param>
		/// <returns></returns>
		public static List<Vertice> GetListaAresta( Grafo grafo, bool inicio )
		{
			List<Vertice> listaInicio = new List<Vertice>( );
			List<Vertice> listaFim = new List<Vertice>( );

			foreach( Aresta aresta in grafo.Arestas )
			{
				if( inicio )
					listaInicio.Add( aresta.Origem );
				else
					listaFim.Add( aresta.Destino );
			}

			if( inicio )
				return listaInicio;
			else
				return listaFim;
		}

		/// <summary>
		/// Pega a lista de vértices adjacentes.
		/// </summary>
		/// <param name="grafo">O grafo a ser analisado.</param>
		/// <param name="vertice">O vértice a ser analisado.</param>
		/// <returns>Uma List<Vertice> contendo os vértices adjacentes.</Vertice></returns>
		public static List<Vertice> GetAdjacentes( Grafo grafo, Vertice vertice )
		{
			var vertices = grafo.Arestas.Where( a => a.Origem.Nome.Equals( vertice.Nome ) ).Select( a => a.Destino );

			if( !grafo.isDirigido )
			{
				var v = grafo.Arestas.Where( a => a.Destino.Nome.Equals( vertice.Nome ) ).Select( a => a.Origem );
				vertices = vertices.Union( v );

				List<Vertice> resultado = vertices.ToList( );

				//
				// Removendo os itens duplicados
				//
				foreach( Vertice vertex in vertices )
				{
					if( resultado.Count( a => a.Nome == vertex.Nome ) > 1 )
						resultado.Remove( resultado.FindLast( a => a.Nome == vertex.Nome ) );
				}

				vertices = resultado;
			}

			return vertices.ToList( );
		}

		/// <summary>
		/// Seta a lista de aresta de um grafo de acordo com uma string.
		/// Será lido todos os números inteiros da string e para cada par de
		/// números, uma aresta será criada.
		/// </summary>
		/// <param name="grafo">O grafo a ter as arestas adicionadas.</param>
		/// <param name="text">O texto a ser verificado</param>
		public static void SetArestasFromString( Grafo grafo, string text )
		{
			List<string> m_lista = new List<string>( );

			// Varrendo a string e dando um match para encontrar os números
			m_lista = Regex.Split( text, @"\D+" ).Where( c => c.Trim( ) != "" ).ToList( );

			int countNome = 1;

			// Passando em cada par, criando uma nova aresta, e adicinando ao grafo
			for( int i = 0; i < m_lista.Count; i += 2 )
			{
				Vertice origem = new Vertice( m_lista[ i ] );
				Vertice destino = new Vertice( m_lista[ i + 1 ] );

				string nome = grafo.Arestas.Where( a =>
											( a.Destino.Nome == origem.Nome && a.Origem.Nome == destino.Nome ) ||
											( a.Destino.Nome == destino.Nome && a.Origem.Nome == origem.Nome ) ).Select( b => b.Nome ).FirstOrDefault( );

				grafo.AddAresta( origem, destino, nome == null ? countNome.ToString( ) : nome );

				if( nome == null )
					countNome++;
			}
		}
	}
}

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
		/// Monta a lista de adjacência do grafo.
		/// </summary>
		/// <param name="grafo">O grafo a ser verificado.</param>
		/// <returns>Para cada vértice do grafo será criada uma lista de vértices adjacentes.</returns>
		public static List<List<Vertice>> GetListaAdjacencia( Grafo grafo )
		{
			List<List<Vertice>> m_lista = new List<List<Vertice>>( );

			for( int i = 0; i < grafo.Vertices.Count; i++ )
			{
				List<Vertice> m_listaVertices = GetAdjacentes( grafo, grafo.Vertices[ i ] );

				m_lista.Add( new List<Vertice>( ) );

				foreach( Vertice verticeAdj in m_listaVertices )
				{
					m_lista[ i ].Add( new Vertice( verticeAdj.Nome ) );
				}
			}

			return m_lista;
		}

		/// <summary>
		/// Pega a lista de vértices adjacentes.
		/// </summary>
		/// <param name="grafo">O grafo a ser analisado.</param>
		/// <param name="vertice">O vértice a ser analisado.</param>
		/// <returns>Uma List<Vertice> contendo os vértices adjacentes.</Vertice></returns>
		public static List<Vertice> GetAdjacentes( Grafo grafo, Vertice vertice )
		{
			var vertices = grafo.Arestas.Where( a => a.Origem.Equals( vertice ) ).Select( a => a.Destino );

			if( !grafo.isDigrafo )
			{
				var v = grafo.Arestas.Where( a => a.Destino.Equals( vertice ) ).Select( a => a.Origem );
				vertices = vertices.Union( v );
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
			// {(1,2),(1,5),(2,5),(2,4),(2,3),(3,4),(4,5)}
			// 1,2 1,5 2,1 2,5 2,3 2,4 3,2 3,4 4,2 4,5 4,3 5,4 5,1 5,2

			List<string> m_lista = new List<string>( );

			// Varrendo a string e dando um match para encontrar os números
			m_lista = Regex.Split( text, @"\D+" ).Where( c => c.Trim( ) != "" ).ToList( );

			// Passando em cada par, criando uma nova aresta, e adicinando ao grafo
			for( int i = 0; i < m_lista.Count; i += 2 )
			{
				grafo.AddAresta( new Vertice( m_lista[ i ] ), new Vertice( m_lista[ i + 1 ] ) );
			}
		}

		/// <summary>
		/// Imprime as aresta com as suas respectivas origens e destinos.
		/// </summary>
		/// <param name="grafo">O grafo a ser analisado</param>
		/// <returns>Uma String contendo os dados.</returns>
		public static string PrintArestas( Grafo grafo )
		{
			string listaAresta = "";

			for( int i = 0; i < grafo.Arestas.Count; i++ )
			{
				listaAresta += string.Format( "Origem: {0} - Destino: {1}",
										grafo.Arestas[ i ].Origem,
										grafo.Arestas[ i ].Destino );

				listaAresta += Environment.NewLine;
			}

			return listaAresta;
		}
	}
}

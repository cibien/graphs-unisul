using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Class
{
	public static class Util
	{
		/// <summary>
		/// Constrói a lista de ajacência do grafo.
		/// </summary>
		/// <param name="grafo">O grafo a ser analisado.</param>
		/// <returns>Uma string com a lista de adjacência.</returns>
		public static string MontaListaAdjacencia( Grafo grafo )
		{
			List<List<Vertice>> m_lista = Representacoes.GetListaAdjacencia( grafo );

			string retorno = "Lista de Adjacência" + Environment.NewLine;
			bool imprimeOrigem = true;

			for( int i = 0; i < m_lista.Count; i++ )
			{
				imprimeOrigem = true;

				foreach( Vertice vertice in m_lista[ i ].OrderBy( a => a.Nome ) )
				{
					if( imprimeOrigem )
					{
						retorno += ( i + 1 ) + " -> ";
						imprimeOrigem = false;
					}

					retorno += vertice.Nome += " ->";
				}

				if( retorno.LastIndexOf( '>' ) > 0 && !imprimeOrigem )
					retorno = retorno.Remove( retorno.Length - 3, 3 );

				retorno += Environment.NewLine;
			}

			return retorno;
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

		public static string PrintMatrix( int[ , ] matriz, string textoInicial )
		{
			StringBuilder sb = new StringBuilder( );
			sb.Append( textoInicial );
			sb.Append( Environment.NewLine );

			for( int i = 0; i < matriz.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matriz.GetLength( 1 ); j++ )
				{
					sb.Append( "|" );

					if( matriz[ i, j ] < 0 )
					{
						sb.Append( " " );
						sb.Append( matriz[ i, j ] );
						sb.Append( " " );
					}
					else
					{
						sb.Append( "  " );
						sb.Append( matriz[ i, j ] );
						sb.Append( " " );
					}
				}

				sb.Append( "|" );
				sb.Append( Environment.NewLine );
			}

			return sb.ToString( );
		}

		public static string PrintListaAresta( List<Vertice> lista, bool inicio )
		{
			string retorno = string.Empty;
			bool last = false;

			if( inicio )
				retorno += "g = (";
			else
				retorno += "h = (";


			foreach( Vertice vertice in lista )
			{
				last = lista.Last( ) == vertice;

				retorno += vertice.Nome;

				if( !last )
					retorno += ", ";

				if( lista.Last( ) == vertice )
				{
					retorno += ")";
				}
			}

			return retorno;
		}
	}
}

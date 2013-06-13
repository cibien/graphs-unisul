using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Class
{
	public static class Coloracao
	{
		/// <summary>
		/// Algoritmo de busca em profundidade para coloração do grafo.
		/// </summary>
		/// <param name="grafo">O grafo a ser verificado.</param>
		/// <returns><value>True</value>caso encontre. <value>False</value> caso contrário.</returns>
		public static Dictionary<Vertice, string> BuscaEmProfundidade( Grafo grafo )
		{
			Dictionary<Vertice, string> horarios = new Dictionary<Vertice, string>( );
			Dictionary<Vertice, Vertice> pais = new Dictionary<Vertice, Vertice>( );

			foreach( Vertice v in grafo.Vertices )
			{
				horarios.Add( v, null );
				pais.Add( v, null );
			}

			foreach( Vertice v in grafo.Vertices )
			{
				if( horarios[ v ] == null )
					ColoreVertice( grafo, v, horarios, pais );
			}

			return horarios;
		}

		private static void ColoreVertice( Grafo grafo, Vertice vertice, Dictionary<Vertice, string> horarios, Dictionary<Vertice, Vertice> pais )
		{
			try
			{
				List<String> cores = new List<string>( ) { "amarelo", "vermelho", "azul", "verde" };

				if( horarios[ vertice ] == null )
				{
					List<Aresta> arestasAdj = grafo.Arestas.Where( a => a.Destino.Nome == vertice.Nome || a.Origem.Nome == vertice.Nome ).ToList( );

					foreach( string cor in cores )
					{
						bool pode = true;

						foreach( Aresta aresta in arestasAdj )
						{
							if( horarios[ aresta.Destino ] == cor || horarios[ aresta.Origem ] == cor )
							{
								pode = false;
								break;
							}
						}

						if( pode )
							horarios[ vertice ] = cor;
					}

					foreach( Aresta aresta in arestasAdj )
					{
						if( horarios[ aresta.Destino ] == null )
						{
							pais[ aresta.Destino ] = vertice;
							ColoreVertice( grafo, aresta.Destino, horarios, pais );
						}
					}

					Console.WriteLine( "Vértice {0} foi colorido com a cor {1}.", vertice.Nome, horarios[ vertice ] );
				}
			}
			catch( Exception e )
			{
				Console.WriteLine( "Erro ao tentar colorir. Erro: {0}", e.Message );
			}
		}
	}
}

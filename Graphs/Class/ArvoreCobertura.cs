using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Class
{
	public static class ArvoreCobertura
	{
		public static List<Aresta> Kruskal( Grafo grafo )
		{
			List<Aresta> A = new List<Aresta>( );

			/// 
			/// Passando em cada aresta, ordenada pelo seu Custo
			/// 
			foreach( Aresta aresta in grafo.Arestas.OrderBy( a => a.Peso ) )
			{
				/// 
				/// Se os conjuntos não forem iguais
				/// 
				if( aresta.Origem.Conjunto.Except( aresta.Destino.Conjunto ).Count( ) > 0 )
				{
					/// 
					/// Une os conjuntos
					/// 
					UneConjuntos( grafo, aresta );

					/// 
					/// Adiciona a aresta ao conjunto final
					/// 
					A.Add( aresta );
				}
			}

			return A;
		}

		private static void ImprimeConjuntos( List<Vertice> vertices, Vertice v1, Vertice v2 )
		{
			string retorno = string.Empty;

			retorno += "Unindo vértices: " + v1.Nome + " " + v2.Nome + Environment.NewLine;

			foreach( Vertice vertice in vertices.OrderBy( a => a.Nome ) )
			{
				retorno += "Vértice: " + vertice.Nome + " Conjunto: ";

				foreach( Vertice v in vertice.Conjunto.OrderBy( a => a.Nome ) )
				{
					retorno += v.Nome + ", ";
				}

				retorno += Environment.NewLine;
			}

			System.Windows.Forms.MessageBox.Show( retorno );
		}

		private static List<Vertice> UneConjuntos( List<Vertice> vertices, List<Vertice> cj1, List<Vertice> cj2 )
		{
			List<Vertice> retorno = cj1;

			foreach( Vertice v in cj2 )
				retorno = retorno.Union( vertices.Where( a => a.Nome == v.Nome ).First( ).Conjunto ).ToList( );

			return retorno;
		}

		private static Aresta UneConjuntos( Grafo grafo, Aresta aresta )
		{
			foreach( Vertice v in aresta.Origem.Conjunto )
			{
				foreach( Vertice v2 in aresta.Destino.Conjunto )
				{
					v.Conjunto = UneConjuntos( grafo.Vertices, v.Conjunto, v2.Conjunto );
					v2.Conjunto = UneConjuntos( grafo.Vertices, v2.Conjunto, v.Conjunto );
				}
			}

			return aresta;
		}
	}
}

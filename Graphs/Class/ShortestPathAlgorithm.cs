using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Class
{
	/// <summary>
	/// Classe que possui algoritmos para cálculo da menor distância.
	/// </summary>
	public static class ShortestPathAlgorithm
	{
		private static int INFINITO = 999;

		/// <summary>
		/// Algoritmo de Floyd-Warshall para calcular a matriz de distância do grafo.
		/// </summary>
		/// <param name="adjMat">A matriz de adjacência do grafo.</param>
		/// <returns>A matriz de distância do grafo.</returns>
		public static int[ , ] FloydWarshall( int[ , ] adjMat )
		{
			for( int i = 0; i < adjMat.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < adjMat.GetLength( 1 ); j++ )
				{
					// Caso a origem seja igual ao destino
					// então a distância é 1
					if( i == j )
						adjMat[ i, j ] = 1;
					else if( adjMat[ i, j ] == 0 )
						adjMat[ i, j ] = INFINITO;
				}
			}

			int t = adjMat.GetLength( 0 );
			int[ , ] Cmin = ( int[ , ] )adjMat.Clone( );

			for( int k = 0; k < t; k++ )
			{
				for( int i = 0; i < t; i++ )
				{
					for( int j = 0; j < t; j++ )
					{
						int result = Cmin[ i, k ] + Cmin[ k, j ];
						int min = Math.Min( Cmin[ i, j ], result );

						Cmin[ i, j ] = min;
					}
				}
			}

			for( int i = 0; i < Cmin.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < Cmin.GetLength( 1 ); j++ )
				{
					if( Cmin[ i, j ] == INFINITO )
						Cmin[ i, j ] = -1;
				}
			}

			return Cmin;
		}

		/// <summary>
		/// Calcula o menor caminho para grafos não valorados.
		/// </summary>
		/// <param name="grafo">O grafo a ser verificado.</param>
		/// <param name="origem">O grafo de origem.</param>
		/// <param name="destino">O grafo de destino.</param>
		/// <param name="caminhoPercorrido">O caminho percorrido para o menor caminho.</param>
		/// <returns>A quantidade de arestas percorridas.</returns>
		public static int CalculaMenorCaminho( Grafo grafo, Vertice origem, Vertice destino, List<Vertice> caminhoPercorrido )
		{
			int menor = Int32.MaxValue;
			int custo = 0;

			caminhoPercorrido.Add( origem );

			if( origem.Nome.Equals( destino.Nome ) )
				return custo;

			List<Vertice> caminhoAnterior = new List<Vertice>( caminhoPercorrido );
			List<Vertice> caminho = null;

			List<Vertice> adjancentes = Representacoes.GetAdjacentes( grafo, origem );

			if( adjancentes.Count == 0 )
				return Int32.MaxValue;

			foreach( Vertice adj in adjancentes.OrderBy( a => a.Nome ) )
			{
				caminho = new List<Vertice>( caminhoAnterior );
				custo = Int32.MaxValue;

				if( !caminho.Exists( a => a.Nome.Equals( adj.Nome ) ) )
					return custo = 1 + CalculaMenorCaminho( grafo, adj, destino, caminho );
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

	}
}

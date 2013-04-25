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
		/// <summary>
		/// Define o valor alto para informar que não há caminho entre dois vértices.
		/// </summary>
		public static int INFINITO = 999;

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
						adjMat[ i, j ] = 0;
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

			for( int i = 0; i < Cmin.GetLength(0); i++ )
			{
				for( int j = 0; j < Cmin.GetLength(1); j++ )
				{
					if( Cmin[ i, j ] == INFINITO )
						Cmin[ i, j ] = 0;
				}
			}

			return Cmin;
		}

		/// <summary>
		/// Algoritmo para calcular o menor caminho para para todos
		/// os vértices de acordo com a origem.
		/// </summary>
		/// <param name="vertices">O conjunto de vértices do grafo.</param>
		/// <param name="arestas">O conjunto de arestas do grafo.</param>
		/// <param name="origem">O vértice de origem a ser verificado.</param>
		/// <returns>A lista de vértices do grafo com seus valores preenchidos.</returns>
		public static List<Vertice> Dijkstra( List<Vertice> vertices, List<Aresta> arestas, Vertice origem )
		{
			List<Vertice> cpVertices = vertices;

			foreach( Vertice v in cpVertices )
			{
				if( v.Nome == origem.Nome )
					v.Distancia = 0;
				else
					v.Distancia = INFINITO;

				v.Caminho = null;
			}

			for( int i = 0; i < cpVertices.Count; i++ )
			{
				foreach( Aresta uv in arestas )
				{
					Vertice u = cpVertices.Where( a => a.Nome == uv.Origem.Nome ).First( );
					Vertice v = cpVertices.Where( a => a.Nome == uv.Destino.Nome ).First( );

					if( v.Distancia > ( u.Distancia + uv.Peso ) )
					{
						v.Distancia = u.Distancia + uv.Peso;
						v.Caminho = u;
					}
				}
			}

			return cpVertices;
		}

		/// <summary>
		/// Algoritmo para calcular o menor caminho para para todos
		/// os vértices de acordo com a origem.
		/// Verificando também se há algum ciclo negativo.
		/// </summary>
		/// <param name="vertices">O conjunto de vértices do grafo.</param>
		/// <param name="arestas">O conjunto de arestas do grafo.</param>
		/// <param name="origem">O vértice de origem a ser verificado.</param>
		/// <returns>A lista de vértices do grafo com seus valores preenchidos.</returns>
		public static List<Vertice> BellmanFord( List<Vertice> vertices, List<Aresta> arestas, Vertice origem )
		{
			List<Vertice> cpVertices = vertices;

			foreach( Vertice v in cpVertices )
			{
				if( v.Nome == origem.Nome )
					v.Distancia = 0;
				else
					v.Distancia = INFINITO;

				v.Caminho = null;
			}

			for( int i = 0; i < cpVertices.Count; i++ )
			{
				foreach( Aresta uv in arestas )
				{
					Vertice u = cpVertices.Where( a => a.Nome == uv.Origem.Nome ).First( );
					Vertice v = cpVertices.Where( a => a.Nome == uv.Destino.Nome ).First( );

					if( v.Distancia > ( u.Distancia + uv.Peso ) )
					{
						v.Distancia = u.Distancia + uv.Peso;
						v.Caminho = u;
					}
				}
			}

			foreach( Aresta uv in arestas )
			{
				Vertice u = cpVertices.Where( a => a.Nome == uv.Origem.Nome ).First( );
				Vertice v = cpVertices.Where( a => a.Nome == uv.Destino.Nome ).First( );

				if( v.Distancia > u.Distancia + uv.Peso )
					throw new Exception( "O grafo contém um ciclo negativo." );
			}

			return cpVertices;
		}
	}
}

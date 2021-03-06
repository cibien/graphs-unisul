﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Class
{
	/// <summary>
	/// Classe para operações básicas com matrizes e.g. soma, multiplicação e transposta.
	/// </summary>
	public static class OperacoesMatriz
	{
		/// <summary>
		/// Soma de duas matrizes.
		/// </summary>
		/// <param name="matrizA">A matriz A.</param>
		/// <param name="matrizB">A matriz B.</param>
		/// <returns>A soma das matrizes A e B.</returns>
		public static double[ , ] Soma( double[ , ] matrizA, double[ , ] matrizB )
		{
			double[ , ] matrizResultado = new double[ matrizA.GetLength( 0 ), matrizA.GetLength( 1 ) ];

			for( int i = 0; i < matrizA.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizA.GetLength( 1 ); j++ )
				{
					matrizResultado[ i, j ] = matrizA[ i, j ] + matrizB[ i, j ];
				}
			}

			return matrizResultado;
		}

		public static double[ ] Soma( double[ ] matrizA, double[ ] matrizB )
		{
			if( matrizA.GetLength( 1 ) != matrizB.GetLength( 0 ) )
				return null;

			double[ ] matrizResultado = new double[ matrizA.GetLength( 0 ) ];

			for( int i = 0; i < matrizA.GetLength( 0 ); i++ )
			{
				matrizResultado[ i ] = matrizA[ i ] + matrizB[ i ];
			}

			return matrizResultado;
		}

		/// <summary>
		/// Soma de duas matrizes.
		/// </summary>
		/// <param name="matrizA">A matriz A.</param>
		/// <param name="matrizB">A matriz B.</param>
		/// <returns>A soma das matrizes A e B.</returns>
		public static int[ , ] Soma( int[ , ] matrizA, int[ , ] matrizB )
		{
			int[ , ] matrizResultado = new int[ matrizA.GetLength( 0 ), matrizA.GetLength( 1 ) ];

			for( int i = 0; i < matrizA.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizA.GetLength( 1 ); j++ )
				{
					matrizResultado[ i, j ] = matrizA[ i, j ] + matrizB[ i, j ];
				}
			}

			return matrizResultado;
		}

		public static double[ , ] Multiplica( double[ , ] matrizA, double[ , ] matrizB )
		{
			double[ , ] matrizResultado = new double[ matrizA.GetLength( 0 ), matrizB.GetLength( 1 ) ];

			for( int i = 0; i < matrizResultado.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizResultado.GetLength( 1 ); j++ )
				{
					for( int k = 0; k < matrizA.GetLength( 1 ); k++ )
					{
						matrizResultado[ i, j ] += matrizA[ i, k ] * matrizB[ k, j ];
					}
				}
			}
			return matrizResultado;
		}

		public static int[ , ] Multiplica( int[ , ] matrizA, int[ , ] matrizB )
		{
			int[ , ] matrizResultado = new int[ matrizA.GetLength( 0 ), matrizB.GetLength( 1 ) ];

			for( int i = 0; i < matrizResultado.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizResultado.GetLength( 1 ); j++ )
				{
					for( int k = 0; k < matrizA.GetLength( 1 ); k++ )
					{
						matrizResultado[ i, j ] += matrizA[ i, k ] * matrizB[ k, j ];
					}
				}
			}
			return matrizResultado;
		}

		public static double[ , ] Multiplica( double[ ] matrizA, double[ ] matrizB )
		{
			if( matrizA.GetLength( 0 ) != matrizB.GetLength( 0 ) )
				return null;

			double[ , ] matrizResultado = new double[ matrizA.GetLength( 0 ), matrizB.GetLength( 0 ) ];

			for( int i = 0; i < matrizA.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizB.GetLength( 1 ); j++ )
				{
					for( int k = 0; k < matrizB.GetLength( 0 ); k++ )
					{
						matrizResultado[ i, j ] += matrizA[ i ] + matrizB[ k ];
					}

				}
			}

			return matrizResultado;
		}

		/// <summary>
		/// Transpõe a matriz recebida.
		/// </summary>
		/// <param name="matriz">A matriz a ser transposta.</param>
		/// <returns>A matriz resultante.</returns>
		public static double[ , ] Transposta( double[ , ] matriz )
		{
			double[ , ] matrizResultado = new double[ matriz.GetLength( 1 ), matriz.GetLength( 0 ) ];

			for( int i = 0; i < matrizResultado.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizResultado.GetLength( 1 ); j++ )
				{
					matrizResultado[ i, j ] = matriz[ j, i ];
				}
			}

			return matrizResultado;
		}

		/// <summary>
		/// Transpõe a matriz recebida.
		/// </summary>
		/// <param name="matriz">A matriz a ser transposta.</param>
		/// <returns>A matriz resultante.</returns>
		public static int[ , ] Transposta( int[ , ] matriz )
		{
			int[ , ] matrizResultado = new int[ matriz.GetLength( 1 ), matriz.GetLength( 0 ) ];

			for( int i = 0; i < matrizResultado.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < matrizResultado.GetLength( 1 ); j++ )
				{
					matrizResultado[ i, j ] = matriz[ j, i ];
				}
			}

			return matrizResultado;
		}
	}
}

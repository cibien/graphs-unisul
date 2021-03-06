﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphs.Class;

namespace Graphs
{
	public partial class Principal : Form
	{
		public Principal( )
		{
			InitializeComponent( );
		}

		/// <summary>
		/// Executa a ação do usuário
		/// </summary>
		private void btn_executar_Click( object sender, EventArgs e )
		{
			int numeroVertices = 0;
			bool isDirigido = chk_dirigido.Checked;

			try
			{
				numeroVertices = Convert.ToInt32( txt_nmVertices.Text );
			}
			catch( Exception )
			{
				MessageBox.Show( "Apenas números são permitidos no campo 'Número Vértices'." );
				return;
			}

			Grafo m_grafo = new Grafo( isDirigido );

			for( int i = 1; i <= numeroVertices; i++ )
			{
				m_grafo.AddVertice( i.ToString( ) );
			}

			Representacoes.SetArestasFromString( m_grafo, txt_cjArestas.Text );

			switch( cbx_operacao.Text )
			{
				case "Lista de Incidência":
					ListaIncidencia( m_grafo );
					break;

				case "Matriz de Adjacência":
					MatrizAdjacencia( m_grafo );
					break;

				case "Matriz de Incidência":
					MatrizIncidencia( m_grafo );
					break;

				case "Lista de Aresta":
					ListaAresta( m_grafo );
					break;

				case "Centro do Grafo - Floyd-Warshall":
					CentroGrafoFloyWarshall( m_grafo );
					break;

				case "Menor Caminho - Bellman-Ford":
					CentroGrafoBellmanFord( m_grafo );
					break;

				case "Menor Caminho - Dijkstra":
					CentroGrafoDjikstra( m_grafo );
					break;

				case "Kruskal":
					Kruskal( m_grafo );
					break;

				case "Busca em Profundidade":
					DFS( m_grafo );
					break;

				default:
					break;
			}

			// Grafo valorado
			// (1,2,2) , (1,5,10), (2,3,3), (2,4,7), (3,4,4), (5,3,8), (5,4,5)
			// (1,2,4), (1,8,8), ( 2,3,8), (2,8,11), (3,4,7), (3,6,4), (3,9,2), (4,5,9), (4,6,14), (5,6,10), (6,7,2), (7,8,1), (8,9,7)
			// (1,2,7),(1,4,5),(2,3,8),(2,4,9),(2,5,7),(4,6,6),(4,5,15),(5,6,8),(5,7,9),(6,7,11)
			// (1,2,1), (1,6,1), (2,3,1), (2,4,1), (3,5,1), (3,4,1), (4,5,1), (4,6,1), (5,6,1)
		}

		private void DFS( Grafo m_grafo )
		{
			Dictionary<Vertice, string> horarios = Coloracao.BuscaEmProfundidade( m_grafo );

			StringBuilder sb = new StringBuilder( );

			foreach( var h in horarios )
			{
				sb.Append( h.ToString( ) );
				sb.Append( Environment.NewLine );
			}

			MessageBox.Show( sb.ToString( ) );
		}

		private void Kruskal( Grafo m_grafo )
		{
			List<Aresta> resultado = ArvoreCobertura.Kruskal( m_grafo );

			string retorno = string.Empty;

			foreach( Aresta a in resultado.OrderBy( a => a.Origem.Nome ) )
			{
				retorno += "Origem: " + a.Origem.Nome + " - Destino: " + a.Destino.Nome + " Custo: " + a.Peso + Environment.NewLine;
			}

			MessageBox.Show( retorno );
		}

		private void CentroGrafoFloyWarshall( Grafo m_grafo )
		{
			int[ , ] disMat = ShortestPathAlgorithm.FloydWarshall( Representacoes.GetMatrizAdjacencia( m_grafo ) );

			if( m_grafo.isDirigido )
			{
				int[ , ] matrizCentro = OperacoesMatriz.Soma( disMat, OperacoesMatriz.Transposta( disMat ) );
				MessageBox.Show( Util.PrintMatrizDistancia( matrizCentro, m_grafo.Vertices, "Centro do grafo" ) );
			}
			else
				MessageBox.Show( Util.PrintMatrizDistancia( disMat, m_grafo.Vertices, "Centro do grafo" ) );
		}

		private void CentroGrafoDjikstra( Grafo m_grafo )
		{
			foreach( Vertice v in m_grafo.Vertices )
			{
				List<Vertice> retorno = ShortestPathAlgorithm.Dijkstra( m_grafo.Vertices, m_grafo.Arestas, v );

				StringBuilder sb = new StringBuilder( );

				foreach( Vertice vDestino in m_grafo.Vertices )
				{
					sb.Append( "Menor caminho de " );
					sb.Append( v.ToString( ) );
					sb.Append( " para " );
					sb.Append( vDestino.ToString( ) );
					sb.Append( " é : " );
					sb.Append( vDestino.Distancia == ShortestPathAlgorithm.INFINITO ? "Não existe" : vDestino.Distancia.ToString( ) );
					sb.Append( Environment.NewLine );
				}

				MessageBox.Show( sb.ToString( ) );
			}
		}

		private void CentroGrafoBellmanFord( Grafo m_grafo )
		{
			//int[ , ] disMat = ShortestPathAlgorithm.FloydWarshall( Representacoes.GetMatrizAdjacencia( m_grafo ) );
			//MessageBox.Show( Util.PrintMatrizDistancia( disMat, m_grafo.Vertices, "Matriz de Distância" ) );

			foreach( Vertice v in m_grafo.Vertices )
			{
				List<Vertice> retorno = ShortestPathAlgorithm.Dijkstra( m_grafo.Vertices, m_grafo.Arestas, v );

				StringBuilder sb = new StringBuilder( );

				foreach( Vertice vDestino in m_grafo.Vertices )
				{
					sb.Append( "Menor caminho de " );
					sb.Append( v.ToString( ) );
					sb.Append( " para " );
					sb.Append( vDestino.ToString( ) );
					sb.Append( " é : " );
					sb.Append( vDestino.Distancia == ShortestPathAlgorithm.INFINITO ? "Não existe" : vDestino.Distancia.ToString( ) );
					sb.Append( Environment.NewLine );
				}

				MessageBox.Show( sb.ToString( ) );
			}
		}

		private void ListaAresta( Grafo m_grafo )
		{
			List<Vertice> listaInicio = Representacoes.GetListaAresta( m_grafo, true );
			List<Vertice> listaFim = Representacoes.GetListaAresta( m_grafo, false );

			string retornoIni = Util.PrintListaAresta( listaInicio, true );
			string retornoFim = Util.PrintListaAresta( listaFim, false );

			MessageBox.Show( retornoIni + Environment.NewLine + retornoFim, "Lista de Arestas" );
		}

		private void MatrizIncidencia( Grafo m_grafo )
		{
			int[ , ] matrizIncidencia = Representacoes.GetMatrizIncidencia( m_grafo );
			MessageBox.Show( Util.PrintMatrizDistancia( matrizIncidencia, m_grafo.Vertices, "Matrix de Incidência" ), "Matriz de Incidência" );
		}

		private void MatrizAdjacencia( Grafo m_grafo )
		{
			int[ , ] matrizAdj = Representacoes.GetMatrizAdjacencia( m_grafo );
			MessageBox.Show( Util.PrintMatrizDistancia( matrizAdj, m_grafo.Vertices, "Matrix de Adjacência" ), "Matriz de Incidência" );
		}

		private void ListaIncidencia( Grafo m_grafo )
		{
			string listaAdj = Util.MontaListaAdjacencia( m_grafo );
			MessageBox.Show( listaAdj, "Lista de Incidência" );
		}

		/// <summary>
		/// Fecha o formulário
		/// </summary>
		private void btn_cancelar_Click( object sender, EventArgs e )
		{
			this.Close( );
		}

		/// <summary>
		/// Liberando o botão de executar somente se os campos estiverem preenchidos.
		/// </summary>
		private void txt_nmVertices_TextChanged( object sender, EventArgs e )
		{
			ValidaCampos( );
		}

		/// <summary>
		/// Liberando o botão de executar somente se os campos estiverem preenchidos.
		/// </summary>
		private void txt_cjArestas_TextChanged( object sender, EventArgs e )
		{
			ValidaCampos( );
		}

		/// <summary>
		/// Liberando o botão de executar somente se os campos estiverem preenchidos.
		/// </summary>
		private void cbx_operacao_TextChanged( object sender, EventArgs e )
		{
			ValidaCampos( );
		}

		private void ValidaCampos( )
		{
			bool ok = !string.IsNullOrWhiteSpace( txt_nmVertices.Text ) &&
							   !string.IsNullOrWhiteSpace( txt_cjArestas.Text ) &&
							   !string.IsNullOrWhiteSpace( cbx_operacao.Text );

			btn_executar.Enabled = ok;
		}

	}
}

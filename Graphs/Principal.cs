using System;
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

				case "Centro do Grafo":
					CentroGrafo( m_grafo );
					break;

				default:
					break;
			}

			// {(1,2),(1,5),(2,5),(2,4),(2,3),(3,4),(4,5)}
			// 1,2 1,5 2,1 2,5 2,3 2,4 3,2 3,4 4,2 4,5 4,3 5,4 5,1 5,2
			// {(1,2),(1,4),(2,5),(3,5),(3,6),(4,2),(5,4),(6,6)}
		}

		private void CentroGrafo( Grafo m_grafo )
		{
			int[ , ] matrizDistancia = new int[ m_grafo.Vertices.Count, m_grafo.Vertices.Count ];
			List<Vertice> menorCaminho = new List<Vertice>( );

			for( int i = 0; i < m_grafo.Vertices.Count; i++ )
			{
				for( int j = 0; j < m_grafo.Vertices.Count; j++ )
				{
					int menorCusto = Representacoes.CalculaMenorCaminho( m_grafo, m_grafo.Vertices[ i ], m_grafo.Vertices[ j ], menorCaminho );
					matrizDistancia[ i, j ] = menorCusto;
				}
			}

			MessageBox.Show( Util.PrintMatrix( matrizDistancia, "Matriz de Distância" ) );

			//if( menorCusto == Int32.MaxValue )
			//{
			//	MessageBox.Show( "Este vértice não possui caminho até o vértice de destino" );
			//}
			//else
			//{
			//	string resultado = "Menor caminho entre " + origem.Nome + " e " + destino.Nome + " é: " + menorCusto.ToString( );
			//	resultado += Environment.NewLine + Environment.NewLine;

			//	foreach( Vertice v in menorCaminho )
			//	{
			//		resultado += " => " + v.Nome + " ";
			//	}

			//	MessageBox.Show( resultado );
			//}
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
			MessageBox.Show( Util.PrintMatrix( matrizIncidencia, "Matrix de Incidência" ), "Matriz de Incidência" );
		}

		private void MatrizAdjacencia( Grafo m_grafo )
		{
			int[ , ] matrizAdj = Representacoes.GetMatrizAdjacencia( m_grafo );
			MessageBox.Show( Util.PrintMatrix( matrizAdj, "Matrix de Adjacência" ), "Matriz de Incidência" );
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

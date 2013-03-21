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

		private void btn_executar_Click( object sender, EventArgs e )
		{
			int numeroVertices = 0;
			bool isDirigido = chk_dirigido.Checked;

			if( string.IsNullOrWhiteSpace( txt_nmVertices.Text ) )
			{
				MessageBox.Show( "Apenas números são permitidos no campo 'Número Vértices'." );
				return;
			}

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
			string listaAdj = Util.MontaListaAdjacencia( m_grafo );
			MessageBox.Show( listaAdj );

			int[ , ] matrizAdj = Representacoes.GetMatrizAdjacencia( m_grafo );
			MessageBox.Show( Util.PrintMatrix( matrizAdj, "Matrix de Adjacência" ) );

			int[ , ] matrizIncidencia = Representacoes.GetMatrizIncidencia( m_grafo );
			MessageBox.Show( Util.PrintMatrix( matrizIncidencia, "Matrix de Incidência" ) );

			List<Vertice> listaInicio = Representacoes.GetListaAresta( m_grafo, true );
			List<Vertice> listaFim = Representacoes.GetListaAresta( m_grafo, false );

			string retornoIni = Util.PrintListaAresta( listaInicio, true );
			string retornoFim = Util.PrintListaAresta( listaFim, false );

			MessageBox.Show( retornoIni + Environment.NewLine + retornoFim );

			// {(1,2),(1,5),(2,5),(2,4),(2,3),(3,4),(4,5)}
			// 1,2 1,5 2,1 2,5 2,3 2,4 3,2 3,4 4,2 4,5 4,3 5,4 5,1 5,2
			// {(1,2),(1,4),(2,5),(3,5),(3,6),(4,2),(5,4),(6,6)}
		}
	}
}

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
			bool isDigrafo = chk_digrafo.Checked;

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

			Grafo m_grafo = new Grafo( isDigrafo );

			for( int i = 1; i <= numeroVertices; i++ )
			{
				m_grafo.AddVertice( i.ToString( ) );
			}

			Representacoes.SetArestasFromString( m_grafo, txt_cjArestas.Text );

			MessageBox.Show( Representacoes.PrintArestas( m_grafo ) );
		}
	}
}

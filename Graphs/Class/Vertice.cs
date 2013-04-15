using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
	public class Vertice
	{
		public string Nome { get; set; }
		public bool Visitado { get; set; }

		public Vertice( string nome )
		{
			Nome = nome;
		}

		public override string ToString( )
		{
			return this.Nome;
		}
	}
}

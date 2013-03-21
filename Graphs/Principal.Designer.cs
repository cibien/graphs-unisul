namespace Graphs
{
	partial class Principal
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.txt_nmVertices = new System.Windows.Forms.TextBox();
			this.lbl_nmVertice = new System.Windows.Forms.Label();
			this.lbl_cjArestas = new System.Windows.Forms.Label();
			this.txt_cjArestas = new System.Windows.Forms.TextBox();
			this.btn_executar = new System.Windows.Forms.Button();
			this.chk_dirigido = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txt_nmVertices
			// 
			this.txt_nmVertices.Location = new System.Drawing.Point(107, 9);
			this.txt_nmVertices.Name = "txt_nmVertices";
			this.txt_nmVertices.Size = new System.Drawing.Size(296, 20);
			this.txt_nmVertices.TabIndex = 0;
			// 
			// lbl_nmVertice
			// 
			this.lbl_nmVertice.AutoSize = true;
			this.lbl_nmVertice.Location = new System.Drawing.Point(13, 12);
			this.lbl_nmVertice.Name = "lbl_nmVertice";
			this.lbl_nmVertice.Size = new System.Drawing.Size(88, 13);
			this.lbl_nmVertice.TabIndex = 1;
			this.lbl_nmVertice.Text = "Número Vértices:";
			// 
			// lbl_cjArestas
			// 
			this.lbl_cjArestas.AutoSize = true;
			this.lbl_cjArestas.Location = new System.Drawing.Point(13, 38);
			this.lbl_cjArestas.Name = "lbl_cjArestas";
			this.lbl_cjArestas.Size = new System.Drawing.Size(90, 13);
			this.lbl_cjArestas.TabIndex = 3;
			this.lbl_cjArestas.Text = "Conjunto Arestas:";
			// 
			// txt_cjArestas
			// 
			this.txt_cjArestas.Location = new System.Drawing.Point(107, 35);
			this.txt_cjArestas.Multiline = true;
			this.txt_cjArestas.Name = "txt_cjArestas";
			this.txt_cjArestas.Size = new System.Drawing.Size(296, 116);
			this.txt_cjArestas.TabIndex = 2;
			// 
			// btn_executar
			// 
			this.btn_executar.Location = new System.Drawing.Point(107, 181);
			this.btn_executar.Name = "btn_executar";
			this.btn_executar.Size = new System.Drawing.Size(296, 23);
			this.btn_executar.TabIndex = 4;
			this.btn_executar.Text = "Executar";
			this.btn_executar.UseVisualStyleBackColor = true;
			this.btn_executar.Click += new System.EventHandler(this.btn_executar_Click);
			// 
			// chk_dirigido
			// 
			this.chk_dirigido.AutoSize = true;
			this.chk_dirigido.Location = new System.Drawing.Point(107, 158);
			this.chk_dirigido.Name = "chk_dirigido";
			this.chk_dirigido.Size = new System.Drawing.Size(92, 17);
			this.chk_dirigido.TabIndex = 5;
			this.chk_dirigido.Text = "grafo dirigido?";
			this.chk_dirigido.UseVisualStyleBackColor = true;
			// 
			// Principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 215);
			this.Controls.Add(this.chk_dirigido);
			this.Controls.Add(this.btn_executar);
			this.Controls.Add(this.lbl_cjArestas);
			this.Controls.Add(this.txt_cjArestas);
			this.Controls.Add(this.lbl_nmVertice);
			this.Controls.Add(this.txt_nmVertices);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Principal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Grafos";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt_nmVertices;
		private System.Windows.Forms.Label lbl_nmVertice;
		private System.Windows.Forms.Label lbl_cjArestas;
		private System.Windows.Forms.TextBox txt_cjArestas;
		private System.Windows.Forms.Button btn_executar;
		private System.Windows.Forms.CheckBox chk_dirigido;
	}
}


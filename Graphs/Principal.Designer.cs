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
			this.cbx_operacao = new System.Windows.Forms.ComboBox();
			this.lbl_isDirigido = new System.Windows.Forms.Label();
			this.lbl_operacao = new System.Windows.Forms.Label();
			this.btn_cancelar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txt_nmVertices
			// 
			this.txt_nmVertices.Location = new System.Drawing.Point(107, 9);
			this.txt_nmVertices.Name = "txt_nmVertices";
			this.txt_nmVertices.Size = new System.Drawing.Size(64, 20);
			this.txt_nmVertices.TabIndex = 0;
			this.txt_nmVertices.TextChanged += new System.EventHandler(this.txt_nmVertices_TextChanged);
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
			this.txt_cjArestas.Size = new System.Drawing.Size(296, 58);
			this.txt_cjArestas.TabIndex = 1;
			this.txt_cjArestas.TextChanged += new System.EventHandler(this.txt_cjArestas_TextChanged);
			// 
			// btn_executar
			// 
			this.btn_executar.Enabled = false;
			this.btn_executar.Location = new System.Drawing.Point(149, 217);
			this.btn_executar.Name = "btn_executar";
			this.btn_executar.Size = new System.Drawing.Size(124, 33);
			this.btn_executar.TabIndex = 4;
			this.btn_executar.Text = "Executar";
			this.btn_executar.UseVisualStyleBackColor = true;
			this.btn_executar.Click += new System.EventHandler(this.btn_executar_Click);
			// 
			// chk_dirigido
			// 
			this.chk_dirigido.AutoSize = true;
			this.chk_dirigido.Location = new System.Drawing.Point(110, 164);
			this.chk_dirigido.Name = "chk_dirigido";
			this.chk_dirigido.Size = new System.Drawing.Size(15, 14);
			this.chk_dirigido.TabIndex = 2;
			this.chk_dirigido.UseVisualStyleBackColor = true;
			// 
			// cbx_operacao
			// 
			this.cbx_operacao.AutoCompleteCustomSource.AddRange(new string[] {
            "Lista de Incidência",
            "Matriz de Adjacência",
            "Matriz de Incidência",
            "Lista de Aresta",
            "Centro do Grafo"});
			this.cbx_operacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_operacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_operacao.FormattingEnabled = true;
			this.cbx_operacao.Items.AddRange(new object[] {
            "Lista de Incidência",
            "Matriz de Adjacência",
            "Matriz de Incidência",
            "Lista de Aresta",
            "Centro do Grafo"});
			this.cbx_operacao.Location = new System.Drawing.Point(107, 190);
			this.cbx_operacao.Name = "cbx_operacao";
			this.cbx_operacao.Size = new System.Drawing.Size(296, 21);
			this.cbx_operacao.TabIndex = 3;
			this.cbx_operacao.TextChanged += new System.EventHandler(this.cbx_operacao_TextChanged);
			// 
			// lbl_isDirigido
			// 
			this.lbl_isDirigido.AutoSize = true;
			this.lbl_isDirigido.Location = new System.Drawing.Point(12, 164);
			this.lbl_isDirigido.Name = "lbl_isDirigido";
			this.lbl_isDirigido.Size = new System.Drawing.Size(72, 13);
			this.lbl_isDirigido.TabIndex = 7;
			this.lbl_isDirigido.Text = "Grafo dirigido:";
			// 
			// lbl_operacao
			// 
			this.lbl_operacao.AutoSize = true;
			this.lbl_operacao.Location = new System.Drawing.Point(12, 193);
			this.lbl_operacao.Name = "lbl_operacao";
			this.lbl_operacao.Size = new System.Drawing.Size(57, 13);
			this.lbl_operacao.TabIndex = 8;
			this.lbl_operacao.Text = "Operação:";
			// 
			// btn_cancelar
			// 
			this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancelar.Location = new System.Drawing.Point(279, 217);
			this.btn_cancelar.Name = "btn_cancelar";
			this.btn_cancelar.Size = new System.Drawing.Size(124, 33);
			this.btn_cancelar.TabIndex = 5;
			this.btn_cancelar.Text = "Cancelar";
			this.btn_cancelar.UseVisualStyleBackColor = true;
			this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label1.Location = new System.Drawing.Point(107, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 52);
			this.label1.TabIndex = 3;
			this.label1.Text = "Exemplos:\r\n(1,2,2) , (1,5,10), (2,3,3), (2,4,7), (3,4,4), (5,3,8), (5,4,5)\r\n\r\nSen" +
    "do: (Vértice Origem, Vértice Destino, Peso/Custo Aresta)";
			// 
			// Principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancelar;
			this.ClientSize = new System.Drawing.Size(412, 262);
			this.Controls.Add(this.btn_cancelar);
			this.Controls.Add(this.lbl_operacao);
			this.Controls.Add(this.lbl_isDirigido);
			this.Controls.Add(this.cbx_operacao);
			this.Controls.Add(this.chk_dirigido);
			this.Controls.Add(this.btn_executar);
			this.Controls.Add(this.label1);
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
		private System.Windows.Forms.ComboBox cbx_operacao;
		private System.Windows.Forms.Label lbl_isDirigido;
		private System.Windows.Forms.Label lbl_operacao;
		private System.Windows.Forms.Button btn_cancelar;
		private System.Windows.Forms.Label label1;
	}
}


namespace GerenciadorMei.UI
{
    partial class NovoServico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovoServico));
            this.panel1 = new System.Windows.Forms.Panel();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.buscarProdutos = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.produtos = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buscarCliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.preco = new System.Windows.Forms.TextBox();
            this.cliente = new System.Windows.Forms.TextBox();
            this.nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.data);
            this.panel1.Controls.Add(this.buscarProdutos);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.produtos);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.buscarCliente);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.preco);
            this.panel1.Controls.Add(this.cliente);
            this.panel1.Controls.Add(this.nome);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 384);
            this.panel1.TabIndex = 0;
            // 
            // data
            // 
            this.data.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data.Location = new System.Drawing.Point(15, 176);
            this.data.MinDate = new System.DateTime(2020, 12, 25, 0, 0, 0, 0);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(266, 38);
            this.data.TabIndex = 16;
            // 
            // buscarProdutos
            // 
            this.buscarProdutos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buscarProdutos.BackgroundImage")));
            this.buscarProdutos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buscarProdutos.FlatAppearance.BorderSize = 0;
            this.buscarProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscarProdutos.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarProdutos.Location = new System.Drawing.Point(448, 50);
            this.buscarProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.buscarProdutos.Name = "buscarProdutos";
            this.buscarProdutos.Size = new System.Drawing.Size(29, 24);
            this.buscarProdutos.TabIndex = 15;
            this.buscarProdutos.UseVisualStyleBackColor = true;
            this.buscarProdutos.Click += new System.EventHandler(this.buscarProdutos_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "PRODUTOS:";
            // 
            // produtos
            // 
            this.produtos.Location = new System.Drawing.Point(301, 50);
            this.produtos.Multiline = true;
            this.produtos.Name = "produtos";
            this.produtos.Size = new System.Drawing.Size(144, 24);
            this.produtos.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(301, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(176, 270);
            this.dataGridView1.TabIndex = 12;
            // 
            // buscarCliente
            // 
            this.buscarCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buscarCliente.BackgroundImage")));
            this.buscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buscarCliente.FlatAppearance.BorderSize = 0;
            this.buscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscarCliente.Location = new System.Drawing.Point(241, 237);
            this.buscarCliente.Margin = new System.Windows.Forms.Padding(0);
            this.buscarCliente.Name = "buscarCliente";
            this.buscarCliente.Size = new System.Drawing.Size(40, 40);
            this.buscarCliente.TabIndex = 11;
            this.buscarCliente.UseVisualStyleBackColor = true;
            this.buscarCliente.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "DATA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "VALOR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CLIENTE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DESCRIÇÃO:";
            // 
            // preco
            // 
            this.preco.Location = new System.Drawing.Point(15, 113);
            this.preco.Multiline = true;
            this.preco.Name = "preco";
            this.preco.Size = new System.Drawing.Size(266, 40);
            this.preco.TabIndex = 5;
            this.preco.TextChanged += new System.EventHandler(this.preco_TextChanged);
            // 
            // cliente
            // 
            this.cliente.Location = new System.Drawing.Point(15, 237);
            this.cliente.Multiline = true;
            this.cliente.Name = "cliente";
            this.cliente.Size = new System.Drawing.Size(223, 40);
            this.cliente.TabIndex = 4;
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(15, 50);
            this.nome.Multiline = true;
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(266, 40);
            this.nome.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(179, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOVO SERVIÇO";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(431, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "SALVAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NovoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NovoServico";
            this.Text = "NovoServico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.TextBox cliente;
        private System.Windows.Forms.TextBox preco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buscarCliente;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox produtos;
        private System.Windows.Forms.Button buscarProdutos;
        private System.Windows.Forms.DateTimePicker data;
    }
}
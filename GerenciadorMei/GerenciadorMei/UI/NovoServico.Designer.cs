namespace GerenciadorMei.UI
{
    partial class NovoServico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovoServico));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblValorMaoObra = new System.Windows.Forms.Label();
            this.txtValorMaoObra = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.groupTotal = new System.Windows.Forms.GroupBox();
            this.lblTextoTotal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.groupTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(199, 27);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Ordem de Serviço";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescricao.Location = new System.Drawing.Point(15, 60);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(131, 15);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Descrição do Serviço:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescricao.Location = new System.Drawing.Point(18, 78);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(300, 23);
            this.txtDescricao.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(15, 120);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(49, 15);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCliente.Location = new System.Drawing.Point(18, 138);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(260, 23);
            this.txtCliente.TabIndex = 4;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(284, 137);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(34, 25);
            this.btnBuscarCliente.TabIndex = 5;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // lblValorMaoObra
            // 
            this.lblValorMaoObra.AutoSize = true;
            this.lblValorMaoObra.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblValorMaoObra.Location = new System.Drawing.Point(15, 180);
            this.lblValorMaoObra.Name = "lblValorMaoObra";
            this.lblValorMaoObra.Size = new System.Drawing.Size(114, 15);
            this.lblValorMaoObra.TabIndex = 6;
            this.lblValorMaoObra.Text = "Valor Mão de Obra:";
            // 
            // txtValorMaoObra
            // 
            this.txtValorMaoObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtValorMaoObra.Location = new System.Drawing.Point(18, 198);
            this.txtValorMaoObra.Name = "txtValorMaoObra";
            this.txtValorMaoObra.Size = new System.Drawing.Size(150, 23);
            this.txtValorMaoObra.TabIndex = 7;
            this.txtValorMaoObra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorMaoObra.TextChanged += new System.EventHandler(this.preco_TextChanged);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblData.Location = new System.Drawing.Point(180, 180);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(36, 15);
            this.lblData.TabIndex = 8;
            this.lblData.Text = "Data:";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(183, 199);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(135, 20);
            this.dtpData.TabIndex = 9;
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblProdutos.Location = new System.Drawing.Point(350, 60);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(119, 15);
            this.lblProdutos.TabIndex = 10;
            this.lblProdutos.Text = "Adicionar Produtos:";
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBuscarProduto.Location = new System.Drawing.Point(353, 78);
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(213, 23);
            this.txtBuscarProduto.TabIndex = 11;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAdicionarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarProduto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnAdicionarProduto.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarProduto.Location = new System.Drawing.Point(572, 78);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(40, 23);
            this.btnAdicionarProduto.TabIndex = 12;
            this.btnAdicionarProduto.Text = "+";
            this.btnAdicionarProduto.UseVisualStyleBackColor = false;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.buscarProdutos_Click);
            // 
            // gridProdutos
            // 
            this.gridProdutos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.Location = new System.Drawing.Point(353, 110);
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.Size = new System.Drawing.Size(296, 200);
            this.gridProdutos.TabIndex = 13;
            // 
            // groupTotal
            // 
            this.groupTotal.Controls.Add(this.lblTextoTotal);
            this.groupTotal.Controls.Add(this.lblValorTotal);
            this.groupTotal.Location = new System.Drawing.Point(18, 250);
            this.groupTotal.Name = "groupTotal";
            this.groupTotal.Size = new System.Drawing.Size(300, 100);
            this.groupTotal.TabIndex = 14;
            this.groupTotal.TabStop = false;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoTotal.Location = new System.Drawing.Point(6, 16);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(104, 18);
            this.lblTextoTotal.TabIndex = 0;
            this.lblTextoTotal.Text = "Total a Pagar:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorTotal.Location = new System.Drawing.Point(6, 45);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(128, 38);
            this.lblValorTotal.TabIndex = 1;
            this.lblValorTotal.Text = "R$ 0,00";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(459, 360);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 35);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(559, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 35);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoverProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverProduto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoverProduto.ForeColor = System.Drawing.Color.White;
            this.btnRemoverProduto.Location = new System.Drawing.Point(609, 78);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(40, 23);
            this.btnRemoverProduto.TabIndex = 17;
            this.btnRemoverProduto.Text = "-";
            this.btnRemoverProduto.UseVisualStyleBackColor = false;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // NovoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupTotal);
            this.Controls.Add(this.gridProdutos);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.txtBuscarProduto);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.txtValorMaoObra);
            this.Controls.Add(this.lblValorMaoObra);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NovoServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Serviço";
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.groupTotal.ResumeLayout(false);
            this.groupTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblDescricao;
        public System.Windows.Forms.TextBox txtDescricao; 

        private System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.TextBox txtCliente;   
        public System.Windows.Forms.Button btnBuscarCliente;

        private System.Windows.Forms.Label lblValorMaoObra;
        public System.Windows.Forms.TextBox txtValorMaoObra; 

        private System.Windows.Forms.Label lblData;
        public System.Windows.Forms.DateTimePicker dtpData; 

        private System.Windows.Forms.Label lblProdutos;
        public System.Windows.Forms.TextBox txtBuscarProduto; 
        public System.Windows.Forms.Button btnAdicionarProduto; 
        public System.Windows.Forms.DataGridView gridProdutos; 

        private System.Windows.Forms.GroupBox groupTotal;
        private System.Windows.Forms.Label lblTextoTotal;
        public System.Windows.Forms.Label lblValorTotal; 

        public System.Windows.Forms.Button btnSalvar; 
        public System.Windows.Forms.Button btnCancelar;

        
        public System.Windows.Forms.Button btnRemoverProduto;
    }
}
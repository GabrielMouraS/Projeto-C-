using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GerenciadorMei.Models;      // Certifique-se que seu Model está aqui
using GerenciadorMei.Repositories; // Certifique-se que seu Repository está aqui

namespace GerenciadorMei.UI
{
    public partial class BuscarProdutos : Form
    {
        // Propriedades para devolver os dados para a tela anterior
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        public decimal PrecoSelecionado { get; private set; } // Importante para somar no total

        private readonly ProdutoRepository _repo = new ProdutoRepository();
        private List<Produto> _listaCompletaProdutos;

        public BuscarProdutos()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Load += BuscarProdutos_Load;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void BuscarProdutos_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                _listaCompletaProdutos = _repo.GetAll(); // Pega tudo do banco
                dataGridView1.DataSource = _listaCompletaProdutos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        // Filtro de pesquisa
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var filtro = textBox1.Text.ToLower();

            if (_listaCompletaProdutos != null)
            {
                var listaFiltrada = _listaCompletaProdutos
                                    .Where(p => p.Nome.ToLower().Contains(filtro))
                                    .ToList();
                dataGridView1.DataSource = listaFiltrada;
            }
        }

        // Seleção com Duplo Clique
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Pega o objeto da linha (tem que fazer o cast para Produto)
                var produto = (Produto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Preenche as variáveis públicas
                IdSelecionado = produto.Id;
                NomeSelecionado = produto.Nome;
                PrecoSelecionado = produto.Preco; // Ou .Valor, dependendo do seu Model

                // Retorna OK e fecha
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
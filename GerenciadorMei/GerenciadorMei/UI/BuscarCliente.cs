using System;
using System.Collections.Generic;
using System.Linq; // Importante para usar o filtro (Where)
using System.Windows.Forms;
using GerenciadorMei.Models; // Seu namespace de Models
using GerenciadorMei.Repositories; // Seu namespace de Repositories

namespace GerenciadorMei.UI
{
    public partial class BuscarCliente : Form
    {
        // Propriedades públicas para passar os dados de volta para o NovoServico
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        private readonly ClienteRepository _repo = new ClienteRepository();
        private List<Cliente> _listaCompletaClientes; // Guarda a lista original para filtrar depois

        public BuscarCliente()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Verifica se o clique foi em uma linha válida (e não no cabeçalho da coluna)
            if (e.RowIndex >= 0)
            {
                // 2. Pega a linha atual que foi clicada
                var linhaAtual = dataGridView1.Rows[e.RowIndex];

                // 3. Transforma (Cast) o dado da linha no seu objeto "Cliente"
                // O "DataBoundItem" é o objeto real que está por trás daquela linha visual
                var clienteSelecionado = (GerenciadorMei.Models.Cliente)linhaAtual.DataBoundItem;

                // 4. Preenche as propriedades públicas para enviar de volta pro outro formulário
                this.IdSelecionado = clienteSelecionado.Id;
                this.NomeSelecionado = clienteSelecionado.Nome;

                // 5. Diz que deu tudo certo (OK) e fecha a janela
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ConfigurarGrid()
        {
            // Configurações visuais para parecer uma lista de seleção
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Evento de carregamento e evento de clique
            this.Load += BuscarCliente_Load;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                _listaCompletaClientes = _repo.GetAll(); // Busca todos do banco
                dataGridView1.DataSource = _listaCompletaClientes;

                // Ocultar colunas desnecessárias (opcional)
                // if (dataGridView1.Columns["Telefone"] != null) dataGridView1.Columns["Telefone"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        // Filtra a lista enquanto digita
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var filtro = textBox1.Text.ToLower();

            if (_listaCompletaClientes != null)
            {
                // Filtra onde o Nome contém o que foi digitado
                var listaFiltrada = _listaCompletaClientes
                                    .Where(c => c.Nome.ToLower().Contains(filtro))
                                    .ToList();

                dataGridView1.DataSource = listaFiltrada;
            }
        }

        // Seleciona o cliente ao dar duplo clique
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se clicou em uma linha válida (não no cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Pega o objeto Cliente da linha clicada
                var cliente = (Cliente)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Preenche as propriedades públicas
                IdSelecionado = cliente.Id;
                NomeSelecionado = cliente.Nome;

                // Define o resultado como OK e fecha a janela
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
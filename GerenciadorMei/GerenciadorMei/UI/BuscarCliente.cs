using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GerenciadorMei.Models;
using GerenciadorMei.Repositories;

namespace GerenciadorMei.UI
{
    public partial class BuscarCliente : Form
    {
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        private readonly ClienteRepository _repo = new ClienteRepository();
        private List<Cliente> _listaCompletaClientes;

        public BuscarCliente()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            // Configurações do Grid
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Preencher o ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] {
                "Nome",
                "ID",
                "Email",
                "CPF",
                "Data Nascimento"
            });

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            // --- CORREÇÃO DOS EVENTOS ---
            this.Load += BuscarCliente_Load;

            // Removemos para evitar duplicidade e adicionamos novamente
            dataGridView1.CellDoubleClick -= dataGridView1_CellDoubleClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            // Atenção aqui: Estamos usando os nomes com letra minúscula para casar com o erro
            textBox1.TextChanged -= textBox1_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                _listaCompletaClientes = _repo.GetAll();
                dataGridView1.DataSource = _listaCompletaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        private void AplicarFiltro()
        {
            if (_listaCompletaClientes == null || _listaCompletaClientes.Count == 0) return;

            var texto = textBox1.Text.ToLower();
            var criterio = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(texto))
            {
                dataGridView1.DataSource = _listaCompletaClientes;
                return;
            }

            List<Cliente> listaFiltrada = null;

            switch (criterio)
            {
                case "Nome":
                    listaFiltrada = _listaCompletaClientes
                        .Where(c => c.Nome != null && c.Nome.ToLower().Contains(texto)).ToList();
                    break;
                case "ID":
                    listaFiltrada = _listaCompletaClientes
                        .Where(c => c.Id.ToString().Contains(texto)).ToList();
                    break;
                case "Email":
                    listaFiltrada = _listaCompletaClientes
                        .Where(c => c.Email != null && c.Email.ToLower().Contains(texto)).ToList();
                    break;
                case "CPF":
                    listaFiltrada = _listaCompletaClientes
                        .Where(c => c.Cpf != null && c.Cpf.Replace(".", "").Replace("-", "").Contains(texto)).ToList();
                    break;
                case "Data Nascimento":
                    listaFiltrada = _listaCompletaClientes
                        .Where(c => c.DataNascimento.HasValue &&
                                    c.DataNascimento.Value.ToString("dd/MM/yyyy").Contains(texto)).ToList();
                    break;
                default:
                    listaFiltrada = _listaCompletaClientes
                        .Where(c => c.Nome != null && c.Nome.ToLower().Contains(texto)).ToList();
                    break;
            }

            dataGridView1.DataSource = listaFiltrada;
        }

        // --- MÉTODOS COM NOMES EM MINÚSCULO (PARA CORRIGIR O ERRO) ---

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cliente = (Cliente)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                IdSelecionado = cliente.Id;
                NomeSelecionado = cliente.Nome;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
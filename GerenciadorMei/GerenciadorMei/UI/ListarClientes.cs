using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GerenciadorMei.Models;
using GerenciadorMei.Repositories;

namespace GerenciadorMei.UI
{
    public partial class ListarClientes : Form
    {
        
        private readonly ClienteRepository _repo = new ClienteRepository();

        
        private List<Cliente> _listaOriginal;

        public ListarClientes()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            
            this.Load += ListarClientes_Load;

            
            btnNovo.Click += BtnNovo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnExcluir.Click += BtnExcluir_Click;

            
            txtBusca.TextChanged += TxtBusca_TextChanged;
        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        
        private void CarregarGrid()
        {
            try
            {
                _listaOriginal = _repo.GetAll(); // Busca todos
                gridClientes.DataSource = _listaOriginal; // Joga na tela

                
                // gridClientes.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        
        private void TxtBusca_TextChanged(object sender, EventArgs e)
        {
            if (_listaOriginal == null) return;

            var texto = txtBusca.Text.ToLower();

           
            var listaFiltrada = _listaOriginal.Where(c =>
                c.Nome.ToLower().Contains(texto) ||
                (c.Cpf != null && c.Cpf.Contains(texto)) ||
                (c.Email != null && c.Email.ToLower().Contains(texto))
            ).ToList();

            gridClientes.DataSource = listaFiltrada;
        }

        
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            CadastroCliente formCadastro = new CadastroCliente();

            
            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                CarregarGrid();
            }
        }

        
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (gridClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var clienteSelecionado = (Cliente)gridClientes.SelectedRows[0].DataBoundItem;

            
            CadastroCliente formCadastro = new CadastroCliente();

            
            formCadastro.Tag = clienteSelecionado.Id;

            formCadastro.txtNome.Text = clienteSelecionado.Nome;
            formCadastro.txtTelefone.Text = clienteSelecionado.Telefone;
            formCadastro.txtEmail.Text = clienteSelecionado.Email;
            formCadastro.txtCpf.Text = clienteSelecionado.Cpf;
            formCadastro.txtCnpj.Text = clienteSelecionado.Cnpj;
            formCadastro.txtEndereco.Text = clienteSelecionado.Endereco;

            if (clienteSelecionado.DataNascimento.HasValue)
            {
                formCadastro.dtpDataNasc.Value = clienteSelecionado.DataNascimento.Value;
                formCadastro.checkSemData.Checked = false;
            }
            else
            {
                formCadastro.checkSemData.Checked = true;
            }

            // Abre a tela
            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                CarregarGrid();
            }
        }

        
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (gridClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clienteSelecionado = (Cliente)gridClientes.SelectedRows[0].DataBoundItem;

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir o cliente {clienteSelecionado.Nome}?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    _repo.Excluir(clienteSelecionado.Id);
                    CarregarGrid();
                    MessageBox.Show("Cliente excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }
    }
}
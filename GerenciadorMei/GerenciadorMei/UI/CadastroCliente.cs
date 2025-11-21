using System;
using System.Windows.Forms;
using GerenciadorMei.Models;
using GerenciadorMei.Repositories;

namespace GerenciadorMei.UI
{
    public partial class CadastroCliente : Form
    {
        private readonly ClienteRepository _repo = new ClienteRepository();
        private int _clienteId = 0; 

        
        public CadastroCliente()
        {
            InitializeComponent();
            ConfigurarEventos();
            lblTitulo.Text = "Novo Cliente";
        }

       
        public CadastroCliente(Cliente cliente)
        {
            InitializeComponent();
            ConfigurarEventos();

            
            _clienteId = cliente.Id;
            lblTitulo.Text = "Editar Cliente";

            txtNome.Text = cliente.Nome;
            txtTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;
            txtCpf.Text = cliente.Cpf;
            txtCnpj.Text = cliente.Cnpj;
            txtEndereco.Text = cliente.Endereco;

            
            if (cliente.DataNascimento != null)
            {
                dtpDataNasc.Value = cliente.DataNascimento.Value;
                checkSemData.Checked = false;
            }
            else
            {
                checkSemData.Checked = true;
                dtpDataNasc.Enabled = false;
            }
        }

        
        private void ConfigurarEventos()
        {
            
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            
            checkSemData.CheckedChanged += CheckSemData_CheckedChanged;
        }

        
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            
            var cliente = new Cliente
            {
                Id = _clienteId,
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                Cpf = txtCpf.Text,
                Cnpj = txtCnpj.Text,
                Endereco = txtEndereco.Text,
                
                DataNascimento = checkSemData.Checked ? (DateTime?)null : dtpDataNasc.Value
            };

            try
            {
                if (_clienteId == 0)
                {
                    _repo.Inserir(cliente); 
                }
                else
                {
                    _repo.Atualizar(cliente); 
                }

                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void CheckSemData_CheckedChanged(object sender, EventArgs e)
        {
            
            dtpDataNasc.Enabled = !checkSemData.Checked;
        }
    }
}
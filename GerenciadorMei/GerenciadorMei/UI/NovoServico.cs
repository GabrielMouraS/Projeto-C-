using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GerenciadorMei.Models;
using GerenciadorMei.Repositories;

namespace GerenciadorMei.UI
{
    public partial class NovoServico : Form
    {
        private readonly ServicoRepository _repo = new ServicoRepository();

        // Propriedade para controlar Edição
        public int IdServicoEditar { get; set; } = 0;

        private int _clienteId = 0;
        private List<int> _produtosIdsSelecionados = new List<int>();
        private List<Produto> _listaVisualProdutos = new List<Produto>();
        private decimal _valorMaoObra = 0;

        public NovoServico()
        {
            InitializeComponent();
            ConfigurarGrid();
            this.Load += NovoServico_Load; // Garante que o load carrega os dados
        }

        private void ConfigurarGrid()
        {
            gridProdutos.AutoGenerateColumns = false;
            gridProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProdutos.MultiSelect = false;

            gridProdutos.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Nome", HeaderText = "Produto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            gridProdutos.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Preco", HeaderText = "Valor", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
        }

        private void NovoServico_Load(object sender, EventArgs e)
        {
            // SE TIVER ID, É EDIÇÃO: CARREGA OS DADOS
            if (IdServicoEditar > 0)
            {
                CarregarDadosEdicao();
            }
        }

        private void CarregarDadosEdicao()
        {
            var servico = _repo.GetById(IdServicoEditar);
            if (servico == null) return;

            // 1. Preenche campos simples
            txtDescricao.Text = servico.Nome;
            dtpData.Value = servico.Data;
            _clienteId = servico.ClienteId;
            txtCliente.Text = servico.NomeCliente; // Repository preencheu isso no GetById

            // 2. Preenche Produtos (Precisamos buscar os detalhes dos produtos pra mostrar no grid)
            // Aqui usamos um truque: ProdutoRepository para buscar os detalhes pelo ID
            var prodRepo = new ProdutoRepository();
            _listaVisualProdutos.Clear();
            _produtosIdsSelecionados = servico.Produtos;

            decimal totalProdutos = 0;
            foreach (int idProd in servico.Produtos)
            {
                var p = prodRepo.GetById(idProd); // Você precisa ter esse método no ProdutoRepository
                if (p != null)
                {
                    _listaVisualProdutos.Add(p);
                    totalProdutos += (decimal)p.Preco;
                }
            }
            AtualizarGrid();

            // 3. Calcula Mão de Obra (Total Geral - Total Produtos)
            decimal totalGeral = (decimal)servico.Preco;
            _valorMaoObra = totalGeral - totalProdutos;
            if (_valorMaoObra < 0) _valorMaoObra = 0;

            // Formata a mão de obra na tela
            txtValorMaoObra.Text = _valorMaoObra.ToString("C2");

            CalcularTotal();

            // Muda o título da janela e botão
            this.Text = "Editar Serviço";
            btnSalvar.Text = "ATUALIZAR";
        }

        private void preco_TextChanged(object sender, EventArgs e)
        {
            string apenasDigitos = System.Text.RegularExpressions.Regex.Replace(txtValorMaoObra.Text, "[^0-9]", "");
            if (string.IsNullOrEmpty(apenasDigitos)) { _valorMaoObra = 0; CalcularTotal(); return; }

            _valorMaoObra = decimal.Parse(apenasDigitos) / 100;

            txtValorMaoObra.TextChanged -= preco_TextChanged;
            txtValorMaoObra.Text = _valorMaoObra.ToString("C2");
            txtValorMaoObra.SelectionStart = txtValorMaoObra.Text.Length;
            txtValorMaoObra.TextChanged += preco_TextChanged;

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal totalProdutos = _listaVisualProdutos.Sum(p => (decimal)p.Preco);
            decimal totalGeral = _valorMaoObra + totalProdutos;
            lblValorTotal.Text = totalGeral.ToString("C2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text)) { MessageBox.Show("Informe a descrição."); return; }
            if (_clienteId == 0) { MessageBox.Show("Selecione um cliente."); return; }

            try
            {
                decimal totalProdutos = _listaVisualProdutos.Sum(p => (decimal)p.Preco);
                decimal totalFinal = _valorMaoObra + totalProdutos;

                var servico = new Servico
                {
                    Id = IdServicoEditar, // Se for 0 é novo, se > 0 é update
                    Nome = txtDescricao.Text,
                    Preco = (double)totalFinal,
                    ClienteId = _clienteId,
                    Data = dtpData.Value,
                    Produtos = _produtosIdsSelecionados
                };

                if (IdServicoEditar > 0)
                {
                    _repo.Update(servico);
                    MessageBox.Show("Serviço atualizado!");
                }
                else
                {
                    _repo.Create(servico);
                    MessageBox.Show("Serviço salvo!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void buscarCliente_Click(object sender, EventArgs e)
        {
            using (var form = new BuscarCliente())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _clienteId = form.IdSelecionado; txtCliente.Text = form.NomeSelecionado;
                }
            }
        }

        private void buscarProdutos_Click(object sender, EventArgs e)
        {
            using (var form = new BuscarProdutos())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _produtosIdsSelecionados.Add(form.IdSelecionado);
                    _listaVisualProdutos.Add(new Produto { Id = form.IdSelecionado, Nome = form.NomeSelecionado, Preco = form.PrecoSelecionado });
                    AtualizarGrid(); CalcularTotal();
                }
            }
        }

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (gridProdutos.SelectedRows.Count == 0) return;
            var prod = (Produto)gridProdutos.SelectedRows[0].DataBoundItem;
            _listaVisualProdutos.Remove(prod);
            _produtosIdsSelecionados.Remove(prod.Id);
            AtualizarGrid(); CalcularTotal();
        }

        private void AtualizarGrid()
        {
            gridProdutos.DataSource = null; gridProdutos.DataSource = _listaVisualProdutos;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GerenciadorMei.Models;
using GerenciadorMei.Repositories;

namespace GerenciadorMei.UI
{
    public partial class TelaServicos : Form
    {
        private readonly ServicoRepository _repo = new ServicoRepository();

        // Lista em memória para o filtro funcionar rápido sem ir no banco toda hora
        private List<Servico> _listaOriginal;

        public TelaServicos()
        {
            InitializeComponent();
            ConfigurarTela();
        }

        private void ConfigurarTela()
        {
            // --- 1. CONFIGURAÇÃO DO GRID ---
            gridServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridServicos.MultiSelect = false;
            gridServicos.ReadOnly = true;
            gridServicos.AllowUserToAddRows = false;

            // --- 2. CONFIGURAÇÃO DO FILTRO (COMBOBOX) ---
            cmbFiltroStatus.Items.Clear();
            cmbFiltroStatus.Items.Add("Todos");
            cmbFiltroStatus.Items.Add("Aberto");
            cmbFiltroStatus.Items.Add("Encerrado");
            cmbFiltroStatus.SelectedIndex = 0; // Começa selecionando "Todos"

            // --- 3. EVENTOS ---
            this.Load += TelaServicos_Load;

            // Filtros automáticos (lambda)
            txtBusca.TextChanged += (s, e) => Filtrar();
            cmbFiltroStatus.SelectedIndexChanged += (s, e) => Filtrar();

            // Botões de Ação
            btnNovo.Click += BtnNovo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnMudarStatus.Click += BtnMudarStatus_Click;
        }

        private void TelaServicos_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                _listaOriginal = _repo.GetAll();
                Filtrar(); // Aplica os filtros na lista carregada
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar serviços: " + ex.Message);
            }
        }

        // --- LÓGICA DE FILTRAGEM ---
        private void Filtrar()
        {
            if (_listaOriginal == null) return;

            string texto = txtBusca.Text.ToLower().Trim();
            string statusFiltro = cmbFiltroStatus.SelectedItem?.ToString();

            var listaFiltrada = _listaOriginal.Where(s =>
                // 1. Filtra pelo Texto (Nome do Serviço ou Nome do Cliente)
                (s.Nome.ToLower().Contains(texto) || (s.NomeCliente != null && s.NomeCliente.ToLower().Contains(texto)))
                &&
                // 2. Filtra pelo Status (Se não for "Todos", tem que ser igual)
                (statusFiltro == "Todos" || s.Status == statusFiltro)
            ).ToList();

            gridServicos.DataSource = listaFiltrada;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            // Esconde colunas técnicas que não interessam ao usuário
            if (gridServicos.Columns["Id"] != null) gridServicos.Columns["Id"].Visible = false;
            if (gridServicos.Columns["ClienteId"] != null) gridServicos.Columns["ClienteId"].Visible = false;
            if (gridServicos.Columns["Produtos"] != null) gridServicos.Columns["Produtos"].Visible = false; // Lista de ints não exibe bem

            // Formata Data e Dinheiro
            if (gridServicos.Columns["Data"] != null) gridServicos.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (gridServicos.Columns["Preco"] != null) gridServicos.Columns["Preco"].DefaultCellStyle.Format = "C2";

            // (Opcional) Reordenar colunas para ficar bonito
            if (gridServicos.Columns["Data"] != null) gridServicos.Columns["Data"].DisplayIndex = 0;
            if (gridServicos.Columns["Nome"] != null) gridServicos.Columns["Nome"].HeaderText = "Descrição";
        }

        // --- BOTÃO NOVO ---
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            NovoServico form = new NovoServico();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarDados(); // Recarrega a lista se salvou
            }
        }

        // --- BOTÃO EDITAR ---
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (gridServicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um serviço para editar.", "Atenção");
                return;
            }

            // Pega o serviço selecionado no Grid
            var servicoSelecionado = (Servico)gridServicos.SelectedRows[0].DataBoundItem;

            // Abre a tela NovoServico, mas configurada para EDIÇÃO
            NovoServico form = new NovoServico();

            // --- O SEGREDO ESTÁ AQUI ---
            form.IdServicoEditar = servicoSelecionado.Id; // Passamos o ID
            // ---------------------------

            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarDados(); // Recarrega a lista com as alterações
            }
        }

        // --- BOTÃO EXCLUIR ---
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (gridServicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um serviço para excluir.", "Atenção");
                return;
            }

            var servico = (Servico)gridServicos.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Tem certeza que deseja excluir o serviço '{servico.Nome}' de {servico.NomeCliente}?",
                                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _repo.Excluir(servico.Id);
                    CarregarDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        // --- BOTÃO MUDAR STATUS (Aberto <-> Encerrado) ---
        private void BtnMudarStatus_Click(object sender, EventArgs e)
        {
            if (gridServicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um serviço para alterar o status.", "Atenção");
                return;
            }

            var servico = (Servico)gridServicos.SelectedRows[0].DataBoundItem;
            string novoStatus = (servico.Status == "Aberto") ? "Encerrado" : "Aberto";

            if (MessageBox.Show($"Deseja mudar o status de '{servico.Status}' para '{novoStatus}'?",
                                "Alterar Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _repo.AtualizarStatus(servico.Id, novoStatus);
                    CarregarDados(); // Atualiza a tela
                    MessageBox.Show($"Status alterado para: {novoStatus}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar status: " + ex.Message);
                }
            }
        }
    }
}
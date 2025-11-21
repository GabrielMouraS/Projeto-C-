using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // <--- OBRIGATÓRIO PARA O FILTRO FUNCIONAR
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorMei.Models;
using GerenciadorMei.Repositories;

namespace GerenciadorMei.UI
{
    public partial class TelaServicos : Form
    {
       
        private readonly ServicoRepository _repo = new ServicoRepository();

        
        private List<Servico> _listaOriginal;

        public TelaServicos()
        {
            InitializeComponent();
        }

        private void TelaServicos_Load(object sender, EventArgs e)
        {
            
            CarregarDados();

          
            ConfigurarGrid();
        }

        private void CarregarDados()
        {
            try
            {
                
                _listaOriginal = _repo.GetAll();

                // Joga na grid
                dataGridView1.DataSource = _listaOriginal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
        }

        
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            
            btn_buscar.BackColor = Color.FromArgb(200, 200, 200);
            Task.Delay(120).ContinueWith(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    btn_buscar.BackColor = Color.FromArgb(240, 240, 240);
                }));
            });
           
            Filtrar();
        }

        
        private void Filtrar()
        {
            
            if (_listaOriginal == null || _listaOriginal.Count == 0) return;

            string textoDigitado = BUSCA.Text.ToLower().Trim();

            
            if (string.IsNullOrEmpty(textoDigitado))
            {
                dataGridView1.DataSource = _listaOriginal;
                return;
            }

            
            var listaFiltrada = _listaOriginal
                                .Where(s => s.Status.ToLower().Contains(textoDigitado) ||
                                            s.Data.ToString().Contains(textoDigitado))
                                .ToList();

            dataGridView1.DataSource = listaFiltrada;
        }

        // Evento para filtrar enquanto digita (Dê duplo clique no raiozinho -> TextChanged da TextBox BUSCA)
        private void BUSCA_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void novoServiçoToolS_Click(object sender, EventArgs e)
        {
            NovoServico novoServico = new NovoServico();
            novoServico.ShowDialog();

           
            CarregarDados();
        }

        private void ConfigurarGrid()
        {
           
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true; 
            dataGridView1.AllowUserToAddRows = false; 
        }
    }
}
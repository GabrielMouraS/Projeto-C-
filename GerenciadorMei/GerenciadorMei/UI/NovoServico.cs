using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorMei.Repositories;
using GerenciadorMei.Models;


namespace GerenciadorMei.UI
{
    public partial class NovoServico : Form
    {
        private readonly ServicoRepository _repo = new ServicoRepository();
        private int _clienteId;
        private List<int> _produtosSelecionados = new List<int>();


        public NovoServico()
        {
            InitializeComponent();
        }

        private void NovoServico_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(nome.Text))
            {
                MessageBox.Show("Informe o nome/descrição.");
                return;
            }

            
            string apenasDigitos = System.Text.RegularExpressions.Regex.Replace(preco.Text, "[^0-9]", "");

            if (string.IsNullOrEmpty(apenasDigitos))
            {
                MessageBox.Show("Informe um valor válido.");
                return;
            }

            
            double precoValor = double.Parse(apenasDigitos) / 100.0;
            

            
            if (_clienteId == 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            
            if (_produtosSelecionados.Count == 0)
            {
                MessageBox.Show("Selecione ao menos um produto.");
                return;
            }

            
            var servico = new Servico
            {
                Nome = nome.Text,
                Preco = precoValor, 
                ClienteId = _clienteId,
                Data = data.Value,
                Produtos = _produtosSelecionados
            };

            
            _repo.Create(servico);

            MessageBox.Show("Serviço salvo com sucesso!");
            Close();
        }

        private void preco_TextChanged(object sender, EventArgs e)
        {
           
            string valorSemFormatacao = System.Text.RegularExpressions.Regex.Replace(preco.Text, "[^0-9]", "");

            if (string.IsNullOrEmpty(valorSemFormatacao))
            {
                
                return;
            }

            
            decimal valor = decimal.Parse(valorSemFormatacao) / 100;

           
            preco.Text = valor.ToString("C2");

            
            preco.SelectionStart = preco.Text.Length;
        }

        private void buscarCliente_Click(object sender, EventArgs e)
        {
           
            using (var formBusca = new BuscarCliente())
            {
                
                var resultado = formBusca.ShowDialog();

               
                if (resultado == DialogResult.OK)
                {
                    
                    _clienteId = formBusca.IdSelecionado;

                   
                    cliente.Text = formBusca.NomeSelecionado;

                    
                    cliente.ReadOnly = true;
                    cliente.BackColor = System.Drawing.Color.White; 
                }
            }
        }

        
        private List<Produto> _listaVisualProdutos = new List<Produto>();

        private void buscarProdutos_Click(object sender, EventArgs e)
        {
            using (var formBusca = new BuscarProdutos())
            {
                var resultado = formBusca.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    
                    _produtosSelecionados.Add(formBusca.IdSelecionado);

                    
                    var prodVisual = new Produto
                    {
                        Id = formBusca.IdSelecionado,
                        Nome = formBusca.NomeSelecionado,
                        Preco = formBusca.PrecoSelecionado
                    };
                    _listaVisualProdutos.Add(prodVisual);

                    // 3. Atualiza a Grid do NovoServico para o usuário ver o que adicionou
                    AtualizarGridProdutos();

                    // 4. (Opcional) Atualiza o preço total do serviço automaticamente
                    AtualizarPrecoTotal();
                }
            }
        }

        
        private void AtualizarGridProdutos()
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _listaVisualProdutos;

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        
        private void AtualizarPrecoTotal()
        {
            decimal total = _listaVisualProdutos.Sum(p => p.Preco);
            preco.Text = total.ToString("C2"); // Formata como R$ 
        }

    }
}

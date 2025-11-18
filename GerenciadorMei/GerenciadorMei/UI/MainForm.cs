using System;
using System.Windows.Forms;

namespace GerenciadorMei.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agendarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listarServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Cria uma nova "instância" da sua tela de serviços
            TelaServicos telaServicos = new TelaServicos();

            // 2. Mostra a tela para o usuário
            telaServicos.ShowDialog();
        }
    }
}

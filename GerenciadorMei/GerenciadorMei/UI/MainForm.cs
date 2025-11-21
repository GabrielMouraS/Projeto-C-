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
            
            TelaServicos telaServicos = new TelaServicos();
            

            telaServicos.ShowDialog();
            
        }

        private void novoServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoServico novoServico = new NovoServico();

            novoServico.ShowDialog();
        }
    }
}

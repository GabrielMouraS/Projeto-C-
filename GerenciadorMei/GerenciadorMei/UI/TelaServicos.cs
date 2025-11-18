using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorMei.UI
{
    public partial class TelaServicos : Form
    {
        public TelaServicos()
        {
            InitializeComponent();
        }

        private void TelaServicos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        }
    }
}

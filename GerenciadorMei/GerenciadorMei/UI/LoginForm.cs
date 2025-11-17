using System;
using System.Windows.Forms;
using GerenciadorMei.Repositories; // deve existir e usar namespace GerenciadorMei.Repositories
using GerenciadorMei.Models; // deve existir Usuario com propriedade Senha

namespace GerenciadorMei.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            var repo = new UsuarioRepository();
            var user = repo.BuscarPorEmail(usuario); // método esperado no UsuarioRepository

            if (user != null && user.Senha == senha)
            {
                var main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

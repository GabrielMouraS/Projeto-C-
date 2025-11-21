using System;
using System.Windows.Forms;
using GerenciadorMei.Repositories;
using GerenciadorMei.Models;

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
            string email = txtUsuario.Text.Trim(); 
            string senha = txtSenha.Text;

            var repo = new UsuarioRepository();

            try
            {
                var user = repo.BuscarPorEmail(email);

                
                if (user != null && user.Senha == senha)
                {
                    var main = new MainForm(); 

                    
                    main.FormClosed += (s, args) => this.Close();

                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorretos.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar: " + ex.Message);
            }
        }
    }
}
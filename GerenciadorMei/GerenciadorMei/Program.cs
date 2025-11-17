using System;
using System.Windows.Forms;
using GerenciadorMei.Database;

namespace GerenciadorMei.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inicializa banco e cria tabelas
            new Db();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }
    }
}

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
           
            new Db();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new NovoServico());
            //Application.Run(new TelaServicos());
            //Application.Run(new CadastroCliente());
            //Application.Run(new BuscarCliente());
             Application.Run(new LoginForm());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorMei.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public int ClienteId { get; set; }
        public DateTime Data { get; set; }

        public string Status { get; set; }

        public List<int> Produtos { get; set; } = new List<int>();

        public string NomeCliente { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorMei.Models
{
    class OrdemServico
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; } // Pendente, Em Andamento, Concluído

        public List<int> Servicos { get; set; } = new List<int>();
        public List<int> Produtos { get; set; } = new List<int>();
    }

}

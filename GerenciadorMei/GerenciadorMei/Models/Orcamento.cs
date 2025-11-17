using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorMei.Models
{
    class Orcamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public List<int> Servicos { get; set; } = new List<int>();
        public List<int> Produtos { get; set; } = new List<int>();
    }

}

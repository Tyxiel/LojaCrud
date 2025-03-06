using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LojaCrud.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}

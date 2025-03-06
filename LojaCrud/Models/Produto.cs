using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LojaCrud.Models
{
    public partial class Produto
    {
        public int IdProduto { get; set; }
        public string? Nome { get; set; }
        public int? IdCliente { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Total
        {
            get
            {
                return Quantidade * Valor;
            }
        }
        public DateTime? CriadoEm { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}

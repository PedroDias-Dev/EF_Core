using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Backend.Domains
{

    public class Produto : BaseDomain
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public List<PedidoItem> PedidosItens { get; set; }

        public Produto()
        {
           Id = Guid.NewGuid();
        }
    }
}
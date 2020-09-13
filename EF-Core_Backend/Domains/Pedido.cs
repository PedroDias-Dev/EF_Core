using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Backend.Domains
{
    public class Pedido : BaseDomain
    {
        [Key]
        public Guid  Id { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public List<PedidoItem> PedidosItens { get; set; }

        public Pedido()
        {
            PedidosItens = new List<PedidoItem>();
        }
    }
}
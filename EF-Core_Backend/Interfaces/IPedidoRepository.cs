
using EF_Core_Backend.Domains;
using System;
using System.Collections.Generic;

namespace EF_Core_Backend.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid id);
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}

using Microsoft.EntityFrameworkCore;
using EF_Core_Backend.Domains;
using EF_Core_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_Backend.Contexts;

namespace EF_Core_Backend.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Criação do objeto do tipo Pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                    PedidosItens = new List<PedidoItem>()
                };


                //Percorre a lista de pedidos itens e adiciona a lista
                foreach (var item in pedidosItens)
                {
                    //Adciona um PedidoItem a lista
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, 
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                //Adiciono o pedido ao meu contexto
                _ctx.Pedidos.Add(pedido);
                //Save
                _ctx.SaveChanges();

                return pedido;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id); 
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

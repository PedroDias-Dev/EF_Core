using EF_Core_Backend.Contexts;
using EF_Core_Backend.Domains;
using EF_Core_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Backend.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura
        //Lista todos os produtos cadastrados
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Busca um produto pelo seu Id
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Busca produtos pelo nome
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo ID
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se produto existe
                //Caso não exista gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera suas propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera produto
                _ctx.Produtos.Update(produtoTemp);
                //Salva
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
 
        //Adiciona um novo produto
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona objeto do tipo produto ao dbset do contexto
                _ctx.Produtos.Add(produto);

                //Salva as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Remove um produto
        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(id);

                //Remove o produto do dbSet
                _ctx.Produtos.Remove(produtoTemp);
                //Salva as alteráções do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Inclui erro na tabela de Log
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
